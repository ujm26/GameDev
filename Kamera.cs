using UnityEngine;
using UnityEngine.UIElements;


public class ChangeBackgroundColor : MonoBehaviour
{
        public float yOffSet =1f;
        public Transform Oyuncu;
        
        
                public void Update()
        {
                transform.position = new Vector3(Oyuncu.position.x,transform.position.y,transform.position.z);        
                }     


  

}
