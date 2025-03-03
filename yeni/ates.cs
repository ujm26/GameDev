using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ates : MonoBehaviour
{
    public Transform atescikis;
    public GameObject mermi;
    public float sonatis;
    public float atissuresi;
    public ParticleSystem atesefekti;
    public ParticleSystem duman;

   sesler sesler;

    // Start is called before the first frame update
    void Start()
    {
        sesler=GameObject.FindGameObjectWithTag("sesler").GetComponent<sesler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time-sonatis>=atissuresi)
            {
                Instantiate(mermi, atescikis.position, atescikis.rotation);
                sonatis=Time.time;
                atesefekti.Play();
                duman.Play();
                sesler.PlaySFX(sesler.b);
            }
            
        }
}
}
