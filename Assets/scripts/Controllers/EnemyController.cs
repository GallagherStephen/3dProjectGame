using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius=10;
    Transform target;
    NavMeshAgent agent;

    void Start(){
        target= PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){

        float distance = Vector3.Distance(target.position,transform.position);

        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance<=agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

    }
    void FaceTarget(){

        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation =Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }


    void onDrawGizmos(){

        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
