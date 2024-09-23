using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public string walkAnimationParameter = "isWalking"; // �ȱ� �ִϸ��̼� �Ķ���� �̸�

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ ��������
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void Update()
    {
        // �¿� �̵� �Է� ó��
        float moveDirection = Input.GetAxisRaw("Horizontal");

        // �̵� ���⿡ ���� ��������Ʈ ������ �� �ִϸ��̼� ���
        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (moveDirection < 0)
            {
                spriteRenderer.flipX = true;
            }
            animator.SetBool(walkAnimationParameter, true); // �ȱ� �ִϸ��̼� ���
        }
        else
        {
            animator.SetBool(walkAnimationParameter, false); // �ȱ� �ִϸ��̼� ����
        }
    }
}
