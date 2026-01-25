using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] DebuControllerBehaviour debugController;
    [SerializeField] Vector3 lastCheckpointPosition;
    [SerializeField] GameObject player;
    [SerializeField] TimerBehaviour timer;
    [SerializeField] GameObject deadMenu;


    public void setLastCheckpoinPosition(Vector3 vec)
    {
        lastCheckpointPosition=vec;
    }
    public void GoBackToLastCheckPoint()
    {
        player.GetComponent<Transform>().position=lastCheckpointPosition;
        timer.isTimePaused=false;
        deadMenu.SetActive(false);
    }


    public void died()
    {
        if(debugController.canDie){
        timer.isTimePaused=true;
        deadMenu.SetActive(true);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debugController=GameObject.Find("DebugController").GetComponent<DebuControllerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
