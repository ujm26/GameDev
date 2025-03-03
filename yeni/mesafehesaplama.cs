using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class mesafehesaplama : MonoBehaviour
{
    public Text distance;
    float distanceTraveled;
    Vector3 lastposition;
    
    bool isTrigger = true;
    public Animator anim;
    public GameObject bg;
    public GameObject bg2;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        lastposition = transform.position;
   
       
    }

    // Update is called once per frame
    void Update()
    {
        float distanceThisFrame= Vector3.Distance(lastposition,transform.position);
        distanceTraveled += distanceThisFrame;

        lastposition = transform.position;
        distance.text = "Distance : \n" + Mathf.FloorToInt(distanceTraveled) + " m";
        
    }

    void FixedUpdate()
    {
   
        if (Mathf.Round(distanceTraveled) == 20 && isTrigger)
        {
            
            ArkaPlanDegistirme();
            isTrigger = false;
            
        }
       
    }

     private void ArkaPlanDegistirme()
    {
            anim.SetTrigger("gecis");
            StartCoroutine(asadas());
            
            anim.SetTrigger("bitis");
           

            
        
    }

    IEnumerator asadas()
    {
        
        yield return new WaitForSeconds(1.5f);
        bg.SetActive(false);
     
        bg2.SetActive(true);
        

    }



}