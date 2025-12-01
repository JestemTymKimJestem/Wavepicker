using System.Threading;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [Header("Ustawienia")]
    public Transform aim;           // czerwona kulka / lufa
    public GameObject projectilePrefab; // prefab pocisku
    public float projectileSpeed = 10f;
    public Transform trans;
    [SerializeField] signalGenerator playerSignalGen;
    [SerializeField] TimerBehaviour timer;
    

    [SerializeField] Camera mainCam;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if(!timer.isTimePaused){
        AimAtMouse();
        ShootOnClick();}
    }

    void AimAtMouse()
    {
        // konwersja pozycji myszy do przestrzeni świata
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCam.transform.position.z; // odległość od kamery
        Vector3 worldMouse = mainCam.ScreenToWorldPoint(mousePos);

        // kierunek od GameObjectu do pozycji myszy
        Vector3 direction = worldMouse - transform.position;
        direction.z = 0; // płaszczyzna 2D

        // obracamy dziecko (kulka/lufa)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        trans.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ShootOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // konwersja pozycji myszy do świata
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -mainCam.transform.position.z;
            Vector3 worldMouse = mainCam.ScreenToWorldPoint(mousePos);

            // kierunek lotu
            Vector3 direction = (worldMouse - transform.position).normalized;

            // utwórz pocisk w pozycji lufy
            GameObject bullet = Instantiate(projectilePrefab, aim.position, Quaternion.identity);

            // dodaj mu prędkość
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = direction * projectileSpeed;
            bullet.GetComponent<signalGenerator>().setBaseSignalParameter(playerSignalGen.getParameters());
        }
    }
}
