using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius=10;
    SceneController sc; 
    Transform target;
    NavMeshAgent agent;
    private float playerHealth = 100f;
    public float enemyDamage = 20f;

    public float attackSpeed=1f;
    private float attackCooldown =0f;

    private AudioSource audioSound; // for attacking audio sword sound

    Animator anim;
    void Start(){
        sc =SceneController.FindSceneController();
        target= PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSound = GetComponent<AudioSource>(); // to play attacking sword sound
    }

    void Update(){

        attackCooldown-=Time.deltaTime;
        float distance = Vector3.Distance(target.position,transform.position);

        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <2)
            {
                 if(attackCooldown<=0f)
                {
                     Attacking();
                     attackCooldown = 1f/attackSpeed;
                }

            }
            if(distance<=agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

    }
    void Attacking()
    {
        StartCoroutine (AttackRoutine());
        audioSound.Play();//play sword attack sound!
       
    }
    IEnumerator AttackRoutine()//Coroutine with IEnumerator - the ability to wait and resume from same point .
    {
       
        anim.SetBool("attacking", true); //set the bool condition value to true
        anim.SetInteger("condition", 2); //set condition to 2 so start attacking!
        yield return new WaitForSeconds(0.35f);
        
        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        var player = GameObject.FindGameObjectWithTag("Player");
        
        if(Vector3.Distance(player.transform.position,enemy.transform.position)<=2)
        {
           
            playerHealth-=enemyDamage;
            Debug.Log(player.transform.name+" has been hit. They now have "+playerHealth+" health left!");
            if(playerHealth<=0)
            {
                if(sc)
                {
                    Debug.Log("Scene Controller found");
                    Destroy(player.gameObject);
                    sc.EndGame();

                }
            }
           
        }
        else {
            Debug.Log("Distance is NOT less than or equal to 3");
        }
        anim.SetInteger("condition", 0); //set state condition to be 0 (idle)
        anim.SetBool("attacking", false);//set the bool condition value to false

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
