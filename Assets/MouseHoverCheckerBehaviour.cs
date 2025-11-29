using  System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseHoverCheckerBehaviour : MonoBehaviour
{


    private Vector2 mousePos;
    private RaycastHit2D hit;
    [SerializeField] ResetButtonBehaviour button;

    [SerializeField] float timer = 0f;
    [SerializeField] string[] tags;
    [SerializeField] bool logs = false;
    [SerializeField] string tagNow = "";
    [SerializeField] FunctionPlotter fp;
    [SerializeField] float load=0;
    [SerializeField] int timeToLoad=5;
    [SerializeField] Camera cam;

    void info()
    {
        if (hit.collider != null)
        {
            Debug.Log("Pod kursorem: " + hit.collider.gameObject.name);
        }
    }
    void tagInfo()
    {
        if (hit.collider == null)
            return;
        if(hit.collider.gameObject.tag==null)
            tagNow="null";
        else
        tagNow=hit.collider.gameObject.tag;
        foreach (string tag in tags)
        {
            if (hit.collider.gameObject.tag!=null && hit.collider.gameObject.CompareTag(tag))
            {
                if (logs)
                    Debug.Log("Trafiono obiekt z tagiem: " + tag);
            }
        }
    }
    void connectGrapToGuiGraph()
    {
        foreach(string tag in tags)
        {
            if(hit.collider.gameObject.CompareTag(tag))
            {
                fp.newSignalGen(hit.collider.gameObject.GetComponentInChildren<signalGenerator>());
                button.setNewSignal(hit.collider.gameObject.GetComponentInChildren<signalGenerator>());
            }
        }
    }

    void fullyLoadedAction()
    {
             Debug.Log("Fully loaded");
             load=0;
            connectGrapToGuiGraph();
    }
    void LoadOnARightClick()
{
    bool isHittingValidObject = false;

    if (hit.collider != null)
    {
        foreach (string t in tags)
        {
            if (hit.collider.gameObject.CompareTag(t))
            {
                isHittingValidObject = true;
                break; // nie musimy szukać dalej
            }
        }
    }

    if (Input.GetMouseButton(1))
    {
        if (isHittingValidObject)
        {
            load += Time.deltaTime;

            if (load > timeToLoad)
                fullyLoadedAction();
        }
        else
        {
            load = 0;
        }
    }
    else
    {
        load = 0;
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePos, Vector2.zero);
        tagInfo();
        LoadOnARightClick();
    }
}
