using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject gun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getAGun()
    {
        gun.gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="camera")
            Debug.Log("ups, wykryto mnie");
    }
}
