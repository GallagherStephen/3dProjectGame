using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 2; //speed of the enemy
    public Transform target;
    public Transform myTransform;


    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward*speed*Time.deltaTime); //setting the speed of the enemy 
    }
}
