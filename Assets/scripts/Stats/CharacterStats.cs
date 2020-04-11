using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth{get;private set;}
    public Stat damage;
    public Stat armour;

    void Awake()
    {
        currentHealth=maxHealth;

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(10); 
        }
    }
    public void takeDamage(int damage)
    {
        damage-=armour.getValue();
        damage= Mathf.Clamp(damage,0,int.MaxValue);
        currentHealth -=damage;
        Debug.Log(transform.name+" takes "+damage+" damage. ");

        if(currentHealth<=0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //Die - kill character
        Debug.Log(transform.name+" died. ");
    }
}
