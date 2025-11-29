using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class MouseCircleBehaviour : MonoBehaviour
{

    [SerializeField] Vector2 mousepos;
    private Transform trans;
    [SerializeField] Camera cam;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void mousePosUpdate()
    {
        mousepos=cam.ScreenToWorldPoint(Input.mousePosition);

    }
    void transUpdate()
    {
        trans.position = mousepos;
    }
    // Update is called once per frame
    void Update()
    {
        mousePosUpdate();
        transUpdate();
    }
}
