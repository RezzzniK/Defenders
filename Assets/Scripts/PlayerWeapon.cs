
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] Laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;//refernce for our ball transform component
    [SerializeField] float targetDistance=100f;//how far out target point
    bool isHolding=false;

    void Start(){
        Cursor.visible = false;
    }
    void Update()
    {
        FiringProcess();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    private void FiringProcess()
    {
         foreach (GameObject laser in Laser)
        {
            var emission=laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isHolding;
        }
    }

    public void OnFire(InputValue value){
        isHolding=value.isPressed;  
    }
    public void MoveCrosshair(){
        crosshair.position=Input.mousePosition;
    }
    public void MoveTargetPoint(){
        Vector3 targetPosition=new Vector3(Input.mousePosition.x,Input.mousePosition.y,targetDistance);//getting pos of cursor and for z value our constant distance from ship
        targetPoint.position=Camera.main.ScreenToWorldPoint(targetPosition);//Camera.main.ScreenToWorldPoint(targetPosition); will move our target point to the crosshair pos
    }


    void AimLasers(){
        foreach (GameObject laser in Laser) {
            /*Option number 1 (calculate aiming from lasers position)*/
            //Vector3 fireDirection=targetPoint.position-laser.transform.position;//substracting 2 vectors to get new vector to the target point
             /*Option number 2 (calculate aiming from ships position*/
            Vector3 fireDirection=targetPoint.position-transform.position;
            Quaternion rotationToTarget=Quaternion.LookRotation(fireDirection);//calculating rotation to the vector that we calculated (fireDirection)
            laser.transform.rotation=rotationToTarget;//moving laser(turning) to the point that we calculated
        }
    }
}
