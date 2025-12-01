using UnityEngine;

public class DeadlyRayBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void killItWithFire(GameObject GO)
    {
        Destroy(GO);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TEST");
        if(collision.gameObject.tag=="Player")
            collision.gameObject.GetComponent<PlayerBehaviour>().playerDied();
            
        else
            killItWithFire(collision.gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
            collision.gameObject.GetComponent<PlayerBehaviour>().playerDied();
        else
        killItWithFire(collision.gameObject);
    }
}
