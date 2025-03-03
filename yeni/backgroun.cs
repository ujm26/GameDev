using UnityEngine;

public class backgroun : MonoBehaviour
{
    public float Startpos, length;
    public GameObject cam;
    public float ParallaxEffect;
    
    void Start()
    {
        Startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float distance = cam.transform.position.x* ParallaxEffect;
        float movement = cam.transform.position.x* (1- ParallaxEffect);

        transform.position = new Vector3(Startpos + distance, transform.position.y,transform.position.z);

        if ( movement > Startpos+ length)
        {
            Startpos += length;
        }
       
    }
}

