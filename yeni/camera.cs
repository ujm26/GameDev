using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform karakter; // Karakterin transform'u



    void Update()
    {
        transform.position = new Vector3(karakter.position.x + 4, transform.position.y, transform.position.z);

    }
}