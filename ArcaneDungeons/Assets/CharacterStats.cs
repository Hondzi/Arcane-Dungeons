using System;
using Unity.VisualScripting;
using UnityEngine;


public class CharacterStats : MonoBehaviour {



    //declarace proměných
    private int maxHealth = 250;
    public int currentHealth { get; private set;}

    public Healthbar healthbar;

    public int agility = 1;

    public int critchange = 2;

    public int MaxStamina = 50;
public int currentStamina { get; private set;}

    public Stat damage;
    public Stat mdamage;
    public Stat armor;
    public Stat marmor;
    public Stat intelligence;





    // začáteční hodnoty po spuštění hry || nastavování hp a staminy 
    void Awake()
    {
        currentHealth = maxHealth;
        currentStamina = MaxStamina;
        healthbar.SetMaxHealth(maxHealth);

    }



    // tlačítka pro regen staminy + udělení dmg
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentStamina += MaxStamina - currentStamina;
            Debug.Log(transform.name + " Vyregenerovala si si staminu momentalne ji mas: " + currentStamina);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            int randomDamage = UnityEngine.Random.Range(5, 16);
            TakeDamage(randomDamage);
        }
    }



    // armor a úhyb 
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        int randomNumber = UnityEngine.Random.Range(0, 6);
        if (randomNumber == agility)
        {
            damage = 0;
            Debug.Log(transform.name + " Vyhnul si se utoku");
        }




        // damage + crit damage + žraní staminy za útoky
        else
        {
            // ošetření toho aby se bez staminy nemohlo útočit
            if (currentStamina > 0){
                
                // crit útok
                int critdamageR = UnityEngine.Random.Range(0, 16);
                if (critdamageR == critchange)
                {
                    if (currentStamina >= 10)
                    {
                        int Changetomultiplie = UnityEngine.Random.Range(2, 5);
                        damage = Changetomultiplie * damage;
                        currentHealth -= damage;
                        currentStamina -= 10;
                        Debug.Log(transform.name + " Udelil si crit damage v hodnote " + damage + " zbyva ti jeste " + currentStamina + " staminy a " + currentHealth + " zivotu");
                        healthbar.SetHealth(currentHealth);
                    }
                    else
                    {
                        Debug.Log(transform.name + " Nemáš dostatek staminy na provedení utoku, momentalne mas " + currentStamina + " staminy");
                    }
                }
                else
                {
                    // normal útok
                    if (currentStamina >= 4)
                    {
                        currentStamina -= 4;
                        currentHealth -= damage;
                        Debug.Log(transform.name + " Dostal " + damage + " damage " + " zbyva ti jeste " + currentStamina + " staminy a " + currentHealth + " zivotu");
                        healthbar.SetHealth(currentHealth);

                    }
                    else
                    {
                        Debug.Log(transform.name + " Nemáš dostatek staminy na provedení utoku, momentalne mas " + currentStamina + " staminy");
                    }

                }
            }
           


            // Pokud máš 0 životů umřeš
            if (currentHealth <= 0)
            {
                Die();
            }

        }



       
        
    }
    //Event toho co se stane když umřeš  || work in progress
    public virtual void Die()
    {
       
        Debug.Log(transform.name + "died.");
    }
}
