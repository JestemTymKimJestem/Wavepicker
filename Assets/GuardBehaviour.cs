using Unity.Mathematics;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    [SerializeField] public FunctionPlotter fp;
    [SerializeField] bool moveHorizontal=true;
    [SerializeField] bool moveVertical=false;
    [SerializeField] GameObject camera;

    [Header("Start positions")]
    public float startX=0f;
    public float startY=0f;
    [Header("Finish positions")]
    public float finishX=0f;
    public float finishY=0f;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float funcValue=0f;
    [SerializeField] float funcArea=0f;
    [SerializeField] bool isWorking=true;

    [SerializeField] public float cameraAngle=45f;
    private Vector2 lastPosition;
    
    void updateCameraAngle()
    {
    Vector2 movement = rb.position - lastPosition;

    if (movement.sqrMagnitude > 0.0001f) // żeby uniknąć liczenia kąta gdy stoi
        {
        cameraAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
         Debug.Log(this.gameObject.name + " Angle: " + cameraAngle);
        //camera.transform.rotation = Quaternion.Euler(0f, 0f, angle - cameraAngle);
        }

    }

    void moving()
    {
        float funcValue = fp.GetValue();
        lastPosition=rb.position;
        Vector3 newPosition = rb.position;
        if(moveHorizontal)
        newPosition.x = Mathf.LerpUnclamped(startX, finishX, (funcValue + 1f) * 0.5f);
        if(moveVertical)
        newPosition.y = Mathf.LerpUnclamped(startY, finishY, (funcValue + 1f) * 0.5f);
        rb.position = newPosition;

        updateCameraAngle();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void checkingArea()
    {
        funcArea=fp.getFunctionArea();
        if(funcArea<= 1 ){
            isWorking=false;
            camera.SetActive(false);
        }
        else
        {
            isWorking=true;
            camera.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        
        checkingArea();
        moving();
    }
}
