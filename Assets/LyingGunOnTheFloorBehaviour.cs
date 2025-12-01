using Unity.VisualScripting;
using UnityEngine;

public class LyingGunOnTheFloorBehaviour : MonoBehaviour
{
    [SerializeField] GameObject firstTutorialBox;
    [SerializeField] GameObject secondTutorialBox;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
               {
                collision.gameObject.GetComponent<PlayerBehaviour>().getAGun();
                    firstTutorialBox.SetActive(false);
                    secondTutorialBox.SetActive(true);
                    
                    
                    Destroy(this.gameObject);

                }
    }
}
