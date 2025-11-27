using UnityEngine;

public class ResetButtonBehaviour : MonoBehaviour
{





    [SerializeField] signalGenerator gen;

    public void actionOnClicking()
    {
        if(gen!=null)
        gen.resetSecondSignal();
    }
    public void setNewSignal(signalGenerator newGen)
    {
        gen=newGen;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
