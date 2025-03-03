using UnityEngine;

public class kusolusturma : MonoBehaviour
{
    public float Maxwidth1;
    public float width1;
    public float maxzaman1 = 3;
    public GameObject pipethree;
    public float zaman = 0;
     public GameObject dusman2;
     sesler sesler;


    private void Start()
    {
         sesler=GameObject.FindGameObjectWithTag("sesler").GetComponent<sesler>();
    }
    void Update()
    {
         if (zaman > maxzaman1)
        {
            GameObject yeniPipe = Instantiate(pipethree);
            yeniPipe.transform.position = dusman2.transform.position + new Vector3(Random.Range(width1, Maxwidth1),0 , 0);
             sesler.PlaySFX(sesler.d);
            zaman = 0;
            Destroy(yeniPipe,20);
        }
        zaman+=Time.deltaTime;
    }
}
