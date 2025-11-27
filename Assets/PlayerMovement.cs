using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed=5f;
    private Rigidbody2D playerRb;


    private void move(){
        float moveX=Input.GetAxis("Horizontal");
        float moveY=Input.GetAxis("Vertical");
        Vector2 movement=new Vector2(moveX,moveY);
        playerRb.linearVelocity=movement*speed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
