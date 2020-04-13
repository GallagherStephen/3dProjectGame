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
      
    }
    public void TakeDamage(int damage)
    {
        damage-=armour.GetValue();
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
       Destroy(gameObject);
    }
}
