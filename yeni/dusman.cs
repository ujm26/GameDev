using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoruOlusturma : MonoBehaviour
{
    public float maxzaman = 1;
    public float zaman = 0;
    public GameObject pipe;
    public GameObject pipetwo;
    public GameObject pipethree;
    public GameObject pipefour;
    public GameObject pipefive;
    public GameObject pipesix;
    public GameObject pipeseven;
    
   
    public float height;
    public float width;
    
    public float Maxwidth;
    public Transform hero;
    public GameObject dusman1;
    public GameObject dusman2;
    public GameObject dusman3;
    public GameObject dusman4;
    

    void Update()
    {
        GameObject[] pipes = new GameObject[] { pipe, pipetwo, pipethree, pipefour, pipefive, pipesix, pipeseven };
        int randomIndex = Random.Range(0, pipes.Length);

        if (zaman > maxzaman)
        {
            
            GameObject yeniPipe = Instantiate(pipes[randomIndex]);
            if (randomIndex == 2)
            {
                 yeniPipe.transform.position = dusman2.transform.position + new Vector3(Random.Range(width, Maxwidth),0 , 0);
                 zaman = 0;
                 Destroy(yeniPipe,10);

            }
            else if (randomIndex == 3)
            {
                 yeniPipe.transform.position = dusman3.transform.position + new Vector3(Random.Range(width, Maxwidth),0 , 0);
                 zaman = 0;
                 Destroy(yeniPipe,10); 
            }
            else if (randomIndex == 5)
            {
                 yeniPipe.transform.position = dusman4.transform.position + new Vector3(Random.Range(width, Maxwidth),0 , 0);
                 zaman = 0;
                 Destroy(yeniPipe,10); 
            }
            else if (randomIndex == 6)
            {
                 yeniPipe.transform.position = dusman4.transform.position + new Vector3(Random.Range(width, Maxwidth),0 , 0);
                 zaman = 0;
                 Destroy(yeniPipe,10); 
            }

            else
            {
                yeniPipe.transform.position = dusman1.transform.position + new Vector3(Random.Range(width, Maxwidth),0 , 0);
                zaman = 0;
                Destroy(yeniPipe,10);
            }
            
        }
        zaman+=Time.deltaTime;
    }

   
}