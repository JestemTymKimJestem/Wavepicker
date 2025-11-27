using UnityEngine;

public class GuardCameraBehaviour : MonoBehaviour
{
    [SerializeField] FunctionPlotter FR;
    [SerializeField] Transform trans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void rotateCamera()
    {
        Vector2 dir = FR.directionVector;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        trans.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
        // Update is called once per frame
        void Update()
    {
        rotateCamera();
    }
}
