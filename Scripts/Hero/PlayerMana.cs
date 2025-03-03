using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int currentMana;
    public int maxMana = 100;

    private void Start()
    {
        
        currentMana = maxMana;
    }

   
    public void ChangeMana(int amount)
    {
        currentMana += amount;

        
        if (currentMana > maxMana)
            currentMana = maxMana;
        if (currentMana < 0)
            currentMana = 0;

        
        Debug.Log("Current Mana: " + currentMana);
    }
}
