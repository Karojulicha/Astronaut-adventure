using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    private GameObject PanelDamage;
    public AudioClip monsterSound;
    public float health = 5;
    private float maxHealth = 5;
    public HealthUI healthUI;

    void Start()
    {
        healthUI.InstanceInitialization(maxHealth);

        PanelDamage = GameObject.Find("PanelRed");

        if (PanelDamage != null)
        {
            PanelDamage.SetActive(false);
        }
    }

    private IEnumerator TimeDisableDamagePanel()
    {
        yield return new WaitForSeconds(1f);
        PanelDamage.SetActive(false);
    }

    private IEnumerator WaitingBeforeGameOver(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.instance.GameOver();
    }

    public void TakeDamagePlayer(float damage)
    {
        health -= damage;

        // Evitar valores fuera del rango
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health > 0 && PanelDamage != null)
        {
            AudioManager.Instance.PlaySFX(monsterSound); ;
            PanelDamage.SetActive(true);
            StartCoroutine(TimeDisableDamagePanel());
            healthUI.UpdateHealth(health);
            Debug.Log(health);
        }
        else
        {
            AudioManager.Instance.PlaySFX(monsterSound); ;
            PanelDamage.SetActive(true);
            TextInfoManager.Instance.ShowInfoForSeconds("Misión fallida. Las criaturas protegieron su territorio", 2f);
            StartCoroutine(WaitingBeforeGameOver(2f));
        }

    }

    // public void UpdateLifeDisplay(float health)
    // {
    //     int completeHelmet = Mathf.FloorToInt(health);
    //     bool hasDamageHelmet = health % 1 == 0.5f;
    // }
}
