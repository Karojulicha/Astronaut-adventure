using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBase : MonoBehaviour
{
    void Start()
    {
        firstMessage();
    }

    private void firstMessage ()
    {
        TextInfoManager.Instance.ShowInfoForSeconds("Recolecta las muestras y regresa pronto. Nuestros sensores detectan actividad inusual en la zona. ¡Ten cuidado!", 6f);
    }
}
