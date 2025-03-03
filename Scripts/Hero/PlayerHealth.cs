using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 50;

    public bool playerprefsil;

    private void Awake()
    {
        if (playerprefsil == true)
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {

        }
        
    }

   
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

       
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (currentHealth < 0)
            currentHealth = 0;

        
        Debug.Log("Current Health: " + currentHealth);
    }

}
