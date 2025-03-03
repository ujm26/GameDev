using UnityEngine;

public class atesadam : MonoBehaviour
{
    public Transform atescikis;
    public GameObject mermi;

    private float maxzaman1 = 3.5f;
    public float zaman = 0;
    public ParticleSystem atesefekti;
    public ParticleSystem duman;
    sesler sesler;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sesler=GameObject.FindGameObjectWithTag("sesler").GetComponent<sesler>();
    }

    void Update()
    {
        if (zaman>maxzaman1)
        {
            
            Instantiate(mermi, atescikis.position, atescikis.rotation);
            
            atesefekti.Play();
            duman.Play();
            zaman = 0;
            sesler.PlaySFX(sesler.b);

        }
        zaman+=Time.deltaTime;
    }
}
