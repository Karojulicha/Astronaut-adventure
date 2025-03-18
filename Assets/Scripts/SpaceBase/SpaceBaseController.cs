using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBaseController : MonoBehaviour
{
    public GameObject PanelGreen;
    private CollectMinerals collectMinerals;

    private void Start()
    {
        PanelGreen.gameObject.SetActive(false);
        collectMinerals = FindObjectOfType<CollectMinerals>();
    }

    private IEnumerator WaitingBeforeGameWin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.instance.WinGame();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            PanelGreen.gameObject.SetActive(true);
            TextInfoManager.Instance.ShowInfoForSeconds("Misión cumplida. Las muestras están a salvo. ¡Buen trabajo, astronauta!", 6f);
            StartCoroutine(WaitingBeforeGameWin(6f));
        }
    }
}
