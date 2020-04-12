using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;
    public Transform interactionTransform;
    bool hasInteracted = false;
    float stopDistance;
    
    public virtual void Interact(){
        Debug.Log("Interacting with "+ transform.name);
        //method is created to be overwritten in enemy class

    }



    public void setStoppingDistance(float stopDis){
        stopDistance=stopDis;
    }
    public void OnFocused(Transform playerTransform){
        isFocus = true;
         player= playerTransform;
         hasInteracted=false; //so only interact once
    }
    
     public void OnDefocused(){
        isFocus = false;
        player= null;
        hasInteracted=false;
    }
    void Update(){

        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position,interactionTransform.position);
            if(distance<=stopDistance)
            {
                Interact();
                hasInteracted=true;
            }
        }
    } 
    void OnDrawGizmosSelected(){

        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
