using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 5.0f; //decide the repeat rate ..set on 5 secs
    
    void Start()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 11); //destroy object #enemy after 11 sec so not loads spawned
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);

    }
}
