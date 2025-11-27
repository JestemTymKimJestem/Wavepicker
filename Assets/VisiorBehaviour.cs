using UnityEngine;

public class VisiorBehaviour : MonoBehaviour
{
    [SerializeField] bool debugLog=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Visior")
        {
            if (debugLog)
            Debug.Log("Player entered visior");
        }
    }
}
