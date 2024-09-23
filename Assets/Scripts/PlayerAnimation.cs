using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public string walkAnimationParameter = "isWalking"; // 걷기 애니메이션 파라미터 이름

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트 가져오기
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void Update()
    {
        // 좌우 이동 입력 처리
        float moveDirection = Input.GetAxisRaw("Horizontal");

        // 이동 방향에 따라 스프라이트 뒤집기 및 애니메이션 재생
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
            animator.SetBool(walkAnimationParameter, true); // 걷기 애니메이션 재생
        }
        else
        {
            animator.SetBool(walkAnimationParameter, false); // 걷기 애니메이션 중지
        }
    }
}
