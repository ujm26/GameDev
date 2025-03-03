using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public ses sess;
    public int HealthMax = 10;
    public int health;
    public Animator anim;
    void Start()
    {
        health = HealthMax;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            anim.SetBool("oldumu",true);
        

        }

    }   

    public void olum()
    {
        SceneManager.LoadScene(0); 
    }
}
