using UnityEngine;

public class BrokenGuardBehaviour : MonoBehaviour
{
    private Transform guard;
    [SerializeField] public FunctionPlotter fp;
    [SerializeField] bool moveHorizontal=true;
    [SerializeField] bool moveVertical=false;

    [Header("Start positions")]
    public float startX=0f;
    public float startY=0f;
    [Header("Finish positions")]
    public float finishX=0f;
    public float finishY=0f;

    [SerializeField] float funcValue=0f;
    [SerializeField] float funcArea=0f;
    [SerializeField] bool isWorking=true;
    void moveX(){
        funcValue=fp.GetValue();
        float newX=Mathf.LerpUnclamped(startX,finishX,(funcValue+1f)/2f);
        guard.position=new Vector3(newX,guard.position.y,guard.position.z);
    }
    void moveY(){
         funcValue=fp.GetValue();
        float newY=Mathf.LerpUnclamped(startY,finishY,(funcValue+1f)/2f);
        guard.position=new Vector3(guard.position.x,newY,guard.position.z);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guard=GetComponent<Transform>();
    }

    void checkingArea()
    {
        funcArea=fp.getFunctionArea();
        if(funcArea<= 0.5 ){
            isWorking=false;
        }
        else
        {
            isWorking=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkingArea();
        if(moveHorizontal){
            moveX();
        }
        if(moveVertical){
            moveY();
        }
    }
}
