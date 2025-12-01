using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    [SerializeField] signalGenerator signal;
    [SerializeField] string[] tags;
    [SerializeField] float timeToDeath =10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        signal = GetComponent<signalGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDeath<0f)
            Destroy(gameObject);
        timeToDeath-=Time.deltaTime;
    }
    public void functionTransfer(GameObject GO)
    {
        Debug.Log("Trafiłeś w: " + GO.gameObject.name);
        GO.GetComponentInChildren<signalGenerator>().modifySecondSignal(signal.getParameters());
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in tags)
            if (collision.gameObject.CompareTag(tag))
                functionTransfer(collision.gameObject);
            else
             timeToDeath-=1f;
    }
}
