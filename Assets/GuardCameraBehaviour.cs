using Unity.VisualScripting;
using UnityEngine;

public class GuardCameraBehaviour : MonoBehaviour
{
    [SerializeField] FunctionPlotter FR;
    [SerializeField] Transform trans;

    [SerializeField] float cameraAngle=45f;
    [SerializeField] GuardBehaviour GB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void updateAngle()
    {
        cameraAngle = GB.cameraAngle;
    }
    void rotateCamera()
    {
        updateAngle();
        trans.rotation = Quaternion.Euler(0f, 0f,  cameraAngle);

    }
        // Update is called once per frame
        void Update()
    {
        rotateCamera();
    }
}
