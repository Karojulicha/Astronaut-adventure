using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectMinerals : MonoBehaviour
{
    public int countMinerals = 0;
    public int maxMinerals = 6;
    public TextMeshProUGUI TextCounter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mineral"))
        {
            Destroy(other.gameObject);
            countMinerals++;
            updateText();

            if (countMinerals == maxMinerals)
            {
                TextInfoManager.Instance.ShowInfoForSeconds("Muestras completadas. Regresa a la nave", 6f);
            }

        }
    }

    private void updateText()
    {
        if (TextCounter != null)
        {
            TextCounter.text = $"Minerales recolectados: {countMinerals}/{maxMinerals} " ;
        }
    }

}
