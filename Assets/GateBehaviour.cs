using NUnit.Framework;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{

    [SerializeField] GameObject ray;
    [SerializeField] FunctionPlotter signal;
    [SerializeField] bool isOpen=false;
    [SerializeField] float value=1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void checkingForSignal()
    {
        if(-1f<value && value<1f)
        isOpen=true;
        else
        isOpen=false;
        ray.SetActive(!isOpen);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value=signal.getFunctionArea();
        checkingForSignal();
    }
}
