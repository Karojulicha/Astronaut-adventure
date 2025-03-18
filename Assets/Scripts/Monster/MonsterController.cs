using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private PlayerHealthManager playerHealthManager;

    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MonsterDamage();
        }
    }

    private void MonsterDamage()
    {
        if (playerHealthManager != null)
        {
            
            if (gameObject.CompareTag("MosterChomper"))
            {   
                float damageForTouch = 0.5f;
                playerHealthManager.TakeDamagePlayer(damageForTouch);
            }
            if ( gameObject.CompareTag("MosterSpitter")) 
            {
                float damageForTouch = 1;
                playerHealthManager.TakeDamagePlayer(damageForTouch);
            }
        }
    }
}