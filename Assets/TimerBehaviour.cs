using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] float time=0f;
    [SerializeField] float timeLeft=0f;
    public bool isCountingDown=false;
    public bool isTimeRunOut=false;
    public bool isTimeRunning=false;
    public bool isTimePaused=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float getTime(){
        return time;
    }
    void lostTime(){
        Debug.Log("Time's up!");
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimePaused==false)
            {
                if(isCountingDown){
                timeLeft-=Time.deltaTime;
                }


                time+=Time.deltaTime;
            }
        if(timeLeft<=0f && isCountingDown && isTimeRunOut==false){
            isTimeRunOut=true;
            lostTime();
        }
        if(time>10*Mathf.PI){
            time=0f;
            }
    }
}
