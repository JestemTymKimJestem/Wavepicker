using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject gun;
    [SerializeField] GameObject brokenGun; 
    [SerializeField] GameOverController GOCon;
    [SerializeField] ActiveMe guiAct;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerDied()
    {
        GOCon.died();
    }
    public void getAGun()
    {
        brokenGun.gameObject.SetActive(false);
        gun.gameObject.SetActive(true);
        guiAct.active=true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="camera" || collision.tag == "guard" || collision.tag=="Visior")
        {
            GOCon.died();
        }
        if(collision.tag=="checkpoint")
            GOCon.setLastCheckpoinPosition(collision.transform.position);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "camera" || collision.gameObject.tag == "guard" ||collision.gameObject.tag == "Visior")
        {
            GOCon.died();
        }
    }
}
