using Unity.Mathematics;
using UnityEngine;

public class CameraFollowingBehaviour : MonoBehaviour
{
    [SerializeField] Transform cameraTrans;
    [SerializeField] Transform playerTrans;
    [SerializeField] float changeDistance;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTrans=GetComponent<Transform>();
    }
    void updateCameraTrans()
{
    // sprawdzamy dystans 2D
    if (Vector2.Distance(playerTrans.position, cameraTrans.position) > changeDistance)
    {
        Vector3 desiredPos = new Vector3(
            playerTrans.position.x,
            playerTrans.position.y,
            cameraTrans.position.z // zachowujemy Z kamery
        );

        // smooth follow
        cameraTrans.position = Vector3.Lerp(
            cameraTrans.position,
            desiredPos,
            speed * Time.deltaTime
        );
    }
}
    // Update is called once per frame
    void Update()
    {
        updateCameraTrans();
    }
}
