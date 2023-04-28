using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Handler Camera")]
    [SerializeField] Vector2 cameraShake;
    Transform cameraTrans;
    Vector3 initialpos;

void Start()
{
    cameraTrans = Camera.main.transform;
    initialpos = cameraTrans.position;
}
public void CameraShake(){
        HorizontalCameraShake();

}
private void HorizontalCameraShake(){
    LeanTween.moveX(cameraTrans.gameObject,cameraShake.x,0.01f).setOnComplete(VerticalCameraShake);

}   
private void VerticalCameraShake(){
    LeanTween.moveY(cameraTrans.gameObject,cameraShake.y,0.05f).setOnComplete(VerticalCameraShake).setOnComplete(DefaultCameraPosition);

}   
private void DefaultCameraPosition(){
     LeanTween.move(cameraTrans.gameObject,initialpos,0.15f).setOnComplete(VerticalCameraShake);

}  
        
  
}
