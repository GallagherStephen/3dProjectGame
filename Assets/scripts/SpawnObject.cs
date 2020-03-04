using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;


    private void OnTriggerEnter()
    {
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }
}
