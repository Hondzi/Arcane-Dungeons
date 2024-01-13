using System;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set;}

    public int agility = 1;

    public int cridchange = 2;

    public int MaxStamina = 50;
public int currentStamina { get; private set;}

    public Stat damage;
    public Stat mdamage;
    public Stat armor;
    public Stat marmor;
    public Stat intelligence;
    

    
     

 // Celkové životy 
    void Awake() 
    {
        currentHealth = maxHealth;
        currentStamina = MaxStamina;

    }
     public void Update()
    {
     // Stamina    
        if (Input.GetKeyDown(KeyCode.S))
        { currentStamina += MaxStamina-currentStamina;
              Debug.Log(transform.name + "Regenerovala se ti stamina" + currentStamina);
            }
            



        if (Input.GetKeyDown(KeyCode.T))
        {
            int randomDamage = UnityEngine.Random.Range(5, 16);
            TakeDamage(randomDamage);
        }
    }
// jak funguje damage 
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        int randomNumber = UnityEngine.Random.Range(0, 6);
        if(randomNumber == agility)
        {
            damage = 0;
            Debug.Log(transform.name + "Vyhnul si se utoku");
        }

       // Šance na crit 

        else {
            if (currentStamina > 0){
                int criddamage = UnityEngine.Random.Range(0, 16);
                if (criddamage == cridchange)
                {
                    if (currentStamina >= 12)
                    {
                        int Changetomultiplie = UnityEngine.Random.Range(2, 5);
                        damage = Changetomultiplie * damage;
                        currentHealth -= damage;
                        Debug.Log(transform.name + "udelil jsi crit" + damage + "damage.");

                        currentStamina -= 12;
                        Debug.Log(transform.name + "Zbyva ti jeste" + currentStamina + "Staminy");


                    }
                    else
                    {
                        Debug.Log(transform.name + "Nemáš dostatek staminy na provedení utoku " + currentStamina);
                    }
                }
                else
                {
                    if (currentStamina >= 4)
                    {

                        currentStamina -= 4;
                        Debug.Log(transform.name + "Zbyva ti jeste" + currentStamina + "Staminy");
                        currentHealth -= damage;
                        Debug.Log(transform.name + "Dostal" + damage + "damage.");
                        Debug.Log(transform.name + "Zbyva ti jeste" + currentHealth + "zivotu");
                    }
                    else
                    {
                        Debug.Log(transform.name + "Nemáš dostatek staminy na provedení utoku " + currentStamina);
                    }

                }
            }
           



            if (currentHealth <= 0)
            {
                Die();
            }

        }



       
        
    }
    public virtual void Die()
    {
        //Die in some way
        Debug.Log(transform.name + "died.");
    }
}
