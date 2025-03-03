using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    
    public bool a = false;
    public bool b = false;
    public bool c = false;
    public bool d = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void SettingsMenu()
    {
        b = true;
    }


    public void backToMenu()
    {
        d = true;
    }

    public void PlayGame()
    {
        a = true;
    }

    public void QuitGame()
    {
        c = true;
        
    }



    
}
