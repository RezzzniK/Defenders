using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed=10f;
    [SerializeField] float xClampRange;//maximum range that we can move our ship on x axis
    [SerializeField] float yClampRange;//maximum range that we can move our ship on y axis
   [SerializeField] float contorllRotationFactor=34.6f;
   [SerializeField] float contorllPithcFactor=17f;//to move up and down (pithc)
    [SerializeField] float rotationSpeed=8f;
    Vector2 movement;
    float xOffset;
    float yOffset;

    void Update()
    {
        controlShipPosition();
        controlShipRotation();
    }

    private void controlShipPosition()
    {
        xOffset = movement.x * controlSpeed * Time.deltaTime;
        yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawXPos=transform.localPosition.x + xOffset;//we will store here current position to check with MathClamp if its fits our boundaries
        float rawYPos=transform.localPosition.y + yOffset;//we will store here current position to check with MathClamp if its fits our boundaries
        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos,-xClampRange,xClampRange),Mathf.Clamp(rawYPos,-yClampRange,yClampRange) , 0);

    }
    void controlShipRotation(){
        float pitch=-contorllPithcFactor*movement.y;
        float roll=-contorllRotationFactor*movement.x;
        Quaternion targetRotation=Quaternion.Euler(pitch,0,roll);//here we got the movement direction 
        //and becouse we need to rotate in the direction of movment it will be negative degrees
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed*Time.deltaTime);//Lerp will make from this roll- smoothly roatation
    }

    public void OnMove(InputValue value)
    {
       movement=value.Get<Vector2>();
    }
}
