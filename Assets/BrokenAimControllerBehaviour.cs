using UnityEngine;

public class BrokenAimControllerBehaviour : MonoBehaviour
{
    [Header("Ustawienia")]
    public Transform aim;           
    public Transform trans;
    [SerializeField] TimerBehaviour timer;
    

    [SerializeField] Camera mainCam;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if(!timer.isTimePaused)
        AimAtMouse();
    }

    void AimAtMouse()
    {
      
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCam.transform.position.z; 
        Vector3 worldMouse = mainCam.ScreenToWorldPoint(mousePos);

   
        Vector3 direction = worldMouse - transform.position;
        direction.z = 0; // płaszczyzna 2D

   
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        trans.rotation = Quaternion.Euler(0, 0, angle);
    }
}

