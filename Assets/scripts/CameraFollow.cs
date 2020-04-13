using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target;
   public float smoothSpeed =0.125f;
   public Vector3 cameraOffset;

   void FixedUpdate(){
      
       transform.position=target.position+cameraOffset;



   }
}
