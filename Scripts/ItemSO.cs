using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;
    public AttributeToChange attributetochange = new AttributeToChange();
    public int amountToChangeAttribute;


    public bool UseItem()
    {
        if(statToChange == StatToChange.health)
        {
            PlayerHealth playerhealth = GameObject.Find("HealthManager").GetComponent<PlayerHealth>();
            if(playerhealth.currentHealth == playerhealth.maxHealth)
            {
                return false;
            }
            else
            {
                playerhealth.ChangeHealth(amountToChangeStat);
                return true;
            }
            
            
        }
        return false;


            // if(statToChange == StatToChange.mana)
            // {
            //     // "ManaManager" adlı GameObject üzerinden PlayerMana scriptine erişip,
            //     // ChangeMana fonksiyonu ile oyuncunun manasını değiştirmemizi sağlar.
            //     GameObject.Find("ManaManager").GetComponent<PlayerMana>().ChangeMana(amountToChangeStat);
            // }

        
    }

    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        intelligence,
        agility
    };
    
}
