using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ű�� ������ �̵��Ѵ�
public class OnKeyPress_Move : MonoBehaviour
{

    public float speed = 2; // �ӵ���Inspector�� ����
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
    { // ��� �����Ѵ�(���� �ð�����)
      // �̵��Ѵ�
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
        // ���� ������ ������ �ٲ۴�
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
    }
}
