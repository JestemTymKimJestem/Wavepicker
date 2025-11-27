using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCircleBehaviour : MonoBehaviour
{

    private Vector2 mousepos;
    private Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void mousePosUpdate()
    {
        mousepos= Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
