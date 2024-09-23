using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 키를 누르면 이동한다
public class OnKeyPress_Move : MonoBehaviour
{

    public float speed = 2; // 속도：Inspector에 지정
    public float jumpPower;

    float vx = 0;
    bool leftFlag = false;
    Rigidbody2D rbody;



    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        vx = 0;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            Debug.Log("jump");
        }
    }

    void FixedUpdate()
    { // 계속 시행한다(일정 시간마다)
      // 이동한다
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        // 왼쪽 오른쪽 방향을 바꾼다
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
