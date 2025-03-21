using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {
    //   private const float Y_ANGLE_MIN = 0.0f;
    //   private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Vector3 offset = new Vector3(0.0f, 6.0f, -15);
    //   public Transform camTransform;
    //   public float distance = 5.0f;

    //   private float currentX = 0.0f;
    //   private float currentY = 70.0f;
    //   private float sensitivityX = 7.0f;

    //   private float sensitivityY = 7.0f;

    //   private void Start()
    //   {
    //     camTransform = transform;
    //   }

    //   private void Update()
    //   {
    //     currentX += Input.GetAxis("Mouse X") * sensitivityX;
    //     currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

    //     // limitar en Y
    //     currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    //   }

    //   /// <summary>
    //   /// This function is responsible for updating the camera's position and rotation in the LateUpdate phase.
    //   /// The camera follows the lookAt target and maintains a specified distance.
    //   /// </summary>
    //   /// <remarks>
    //   /// The LateUpdate function is called after all Update functions have been called.
    //   /// This ensures that the camera's position and rotation are updated after the player's input has been processed.
    //   /// </remarks>
    //   private void LateUpdate()
    //   {
    //     Vector3 dir = new Vector3(0, 0, -distance);
    //     Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
    //     camTransform.position = lookAt.position + rotation * dir;
    //     camTransform.LookAt(lookAt.position);
    //   }
    private void LateUpdate()
    {
      if (lookAt != null)
      {
        transform.position = lookAt.position + offset;
        transform.LookAt(lookAt);
      }
    }
  }
}
