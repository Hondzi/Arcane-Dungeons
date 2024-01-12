using System;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set;}

    public int agility = 1;

    public Stat damage;
    public Stat mdamage;
    public Stat armor;
    public Stat marmor;
    public Stat intelligence;
    public Stat critchance;
    public Stat stamina;
    
    


    void Awake()
    {
        currentHealth = maxHealth;
    }
     public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            int randomDamage = UnityEngine.Random.Range(5, 16);
            TakeDamage(randomDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        int randomNumber = UnityEngine.Random.Range(0, 6);
        if(randomNumber == agility)
        {
            damage = 0;
            Debug.Log(transform.name + "Vyhnul si se útoku");
        }
        else {
            currentHealth -= damage;
            Debug.Log(transform.name + "Dostal" + damage + "damage.");
            Debug.Log(transform.name + "Zbyva ti jeste" + currentHealth + "zivotu");
        }



        if (currentHealth <= 0) {
            Die();
        }
        
    }
    public virtual void Die()
    {
        //Die in some way
        Debug.Log(transform.name + "died.");
    }
}
