using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private Rigidbody rb;
    private Vector3 input;
    private Vector3 relativePosition;

    private bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        relativePosition = Camera.main.transform.position - this.transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = relativePosition + this.transform.position;

        input = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );

        input.Normalize();
        
        // rb.AddForce(input * speed * Time.deltaTime, ForceMode.Force);
        rb.velocity = new Vector3(
                input.x * speed * Time.deltaTime,
                rb.velocity.y,
                input.z * speed * Time.deltaTime
            );

        // 碰撞检测，会有很多帧， 这样会导致跳跃施力多次
        // 不可取，还是需要能够及时取消状态的检测机制
        // 手动 isJumping是可以的
        if(Vector3.Dot(rb.velocity, Vector3.up) == 0)
        {
            rb.velocity = new Vector3(
                rb.velocity.x,
                jumpSpeed * Input.GetAxisRaw("Jump")/rb.mass,
                rb.velocity.z
            );
        }
        else if (rb.velocity.y !=0)
        {
            print(rb.velocity.y);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.instance.score++;
            UIManager.instance.ScoreChange(GameManager.instance.score.ToString());
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Ground")
            isOnGround = true;
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.collider.tag == "Ground")
            isOnGround = false;
    }
}
