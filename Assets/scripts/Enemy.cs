using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles interaction with the enemy
[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    public float radius = 3f;
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start(){

        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public void Interact(){
        //attack the enemy

        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        if(playerCombat!=null)
        {
            playerCombat.Attack(myStats);

        }


    }
    void OnDrawGizmosSelected(){

        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
