using Unity.Mathematics;
using UnityEngine;

public class GuardBehaviour : MonoBehaviour
{
    private Transform guard;
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
    
    void alternativeMoveX()
    {
    float funcValue = fp.GetValue();
    float t = (funcValue + 1f) * 0.5f;
    float newX = Mathf.LerpUnclamped(startX, finishX, t);

    if (Mathf.Abs(rb.position.x - newX) > 0.1f)
        {
            rb.MovePosition(new Vector2(newX, rb.position.y));
        }
    }

    void alternativeMoveY()
    {
    float funcValue = fp.GetValue();
    float t = (funcValue + 1f) * 0.5f;
    float newY = Mathf.LerpUnclamped(startY, finishY, t);

    if (Mathf.Abs(rb.position.y - newY) > 0.1f)
        {
            rb.MovePosition(new Vector2(rb.position.x, newY));
        }   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guard=GetComponent<Transform>();
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
        if(moveHorizontal){
            alternativeMoveX();
        }
        if(moveVertical){
            alternativeMoveY();
        }
    }
}
