using UnityEngine;

public class yer : MonoBehaviour
{
    public Transform hero;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x,transform.position.y,transform.position.z);
    }
}
