using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   public float smoothSpeed =0.125f;
   public Vector3 cameraOffset;

   void LateUpdate(){
       transform.position=target.position+cameraOffset;

   }
}
