using Unity.Mathematics;
using UnityEngine;

public class CameraFollowingBehaviour : MonoBehaviour
{
    [SerializeField] Transform cameraTrans;
    [SerializeField] Transform playerTrans;
    [SerializeField] float changeDistance;
    [SerializeField] float speed;
    [SerializeField] float modifierMax;
    [SerializeField] float xModifier;
    [SerializeField] float yModifier;

    [SerializeField] float roundingParameter=0.95f;
    [SerializeField] TimerBehaviour timer;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTrans=GetComponent<Transform>();
    }
    void updateModifiers()
    {
        if(Input.GetAxis("Horizontal")==1f)
            xModifier+=Time.deltaTime*speed;
        if(Input.GetAxis("Horizontal")==-1f)
            xModifier-=Time.deltaTime*speed;
        if(Input.GetAxis("Vertical")==1f)
            yModifier+=Time.deltaTime*speed;
        if(Input.GetAxis("Vertical")==-1f)
            yModifier-=Time.deltaTime*speed;

        if(yModifier>modifierMax)
            yModifier=modifierMax;
        if(yModifier<-modifierMax)
            yModifier=-modifierMax;
        if(xModifier>modifierMax)
            xModifier=modifierMax;
        if(xModifier<-modifierMax)
            xModifier=-modifierMax;

        if(math.abs(yModifier)>0.1f && Input.GetAxis("Vertical")==0)
            yModifier=yModifier*roundingParameter;
        if(math.abs(xModifier)>0.1f && Input.GetAxis("Horizontal")==0)
            xModifier=xModifier*roundingParameter;
    }
    public void updateYOffset(float y)
    {
        yOffset=y;
    }
    void updateCameraTrans()
    {
    
        Vector3 desiredPos = new Vector3(playerTrans.position.x+xModifier+xOffset,playerTrans.position.y+yModifier+yOffset,cameraTrans.position.z);

        cameraTrans.position = Vector3.Lerp(cameraTrans.position,desiredPos,speed * Time.deltaTime);
    
    }
    // Update is called once per frame
    void Update()
    {
        if(!timer.isTimePaused){
        updateModifiers();
        updateCameraTrans();}
    }
}
