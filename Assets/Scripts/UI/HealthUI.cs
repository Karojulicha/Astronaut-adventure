// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class HealthUI : MonoBehaviour
// {
//     public GameObject imgHelmetPrefab;
//     public Transform helmetsContainer;
//     public GameObject imgDamageHelmetPrefab;
//     public List<GameObject> heartsHelmetList = new List<GameObject>();


//     public void InstanceInitialization(float maxHealth)
//     {
//         for (int i = 0; i < maxHealth; i++)
//         {
//         Debug.Log("aqui esta la estructura");
//             GameObject heart = Instantiate(imgHelmetPrefab, helmetsContainer);
//             heartsHelmetList.Add(heart);
//         }
//     }

//     public void UpdateHealth(float currentHealth)
//     {
//         int fullHealth = Mathf.FloorToInt(currentHealth);
//         bool hasHalfHealth = currentHealth % 1 != 0;

//         for (int i = 0; i < heartsHelmetList.Count; i++)
//         {
//             heartsHelmetList[i].SetActive(i < fullHealth);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject imgHelmetPrefab;
    public Transform helmetsContainer;
    public GameObject imgDamageHelmetPrefab;
    public List<GameObject> heartsHelmetPool = new List<GameObject>();


    public void InstanceInitialization(float maxHealth)
    {

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject helmetInstance = Instantiate(imgHelmetPrefab, helmetsContainer);
            helmetInstance.SetActive(true);
            heartsHelmetPool.Add(helmetInstance);
        }

        GameObject damageHelmetInstance = Instantiate(imgDamageHelmetPrefab, helmetsContainer);
        damageHelmetInstance.SetActive(false);
        heartsHelmetPool.Add(damageHelmetInstance);
    }

    public void UpdateHealth(float currentHealth)
    {   
        foreach (var helmet in heartsHelmetPool)
        {
            helmet.SetActive(false);
        }

        int fullHealth = Mathf.FloorToInt(currentHealth);
        bool hasHalfHealth = currentHealth % 1 != 0;

        for (int i = 0; i < fullHealth; i++)
        {

            heartsHelmetPool[i].SetActive(true);

            if (hasHalfHealth)
            {
                heartsHelmetPool[heartsHelmetPool.Count - 1].SetActive(true);
            }
        }
    }

}



