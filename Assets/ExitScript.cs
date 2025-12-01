using UnityEngine;

public class ExitScript : MonoBehaviour

{
    [SerializeField] TimerBehaviour timer;
    [SerializeField] GameObject winMenu;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            winMenu.SetActive(true);
            timer.isTimePaused=true;
        }
    }

}
