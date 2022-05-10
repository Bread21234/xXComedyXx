using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{//add iframes?
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject death; //death with death animation

    private GameObject RetryButton;

    // Start is called before the first frame update
    void Start()
    {
        RetryButton = GameObject.FindWithTag("DeadPlayer");
        RetryButton.SetActive(false);

        currentHealth = maxHealth; //sets the original health to be the max
        healthBar.SetMaxHealth(maxHealth); //sets the value of the healthbar slider to be its max as well
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {//enables the retry button
            RetryButton.SetActive(true);
            Instantiate(death,transform.position,Quaternion.identity);
            Destroy(gameObject); //destroys the player upon death and spawns his death animation
        }   
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //function to be called from other classes to take damage from

        healthBar.SetHealth(currentHealth); //healthbar slider follows up
    }

    public void gainHealth(int amount) //opposite of take damage
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
