using UnityEngine;

public class Background : MonoBehaviour
{
   [SerializeField] private Vector2 parallaxeffect;
 private Transform cameraTransform;
 private Vector3 lastCameraPosition;
 private float textureUnitSizeX;
 private void Start()
 {
    cameraTransform = Camera.main.transform;
    lastCameraPosition = cameraTransform.position;
    Sprite sprite = GetComponent<SpriteRenderer>().sprite;
   Texture2D texture = sprite.texture;
   textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
 }
 private void LateUpdate()
 {
    Vector3 deltamovement = cameraTransform.position - lastCameraPosition;
    transform.position += new Vector3(deltamovement.x * parallaxeffect.x, deltamovement.y * parallaxeffect.y);
    lastCameraPosition = cameraTransform.position;

    if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
    {
      float offsetPositionX =(cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
      transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
    }
 }

}

