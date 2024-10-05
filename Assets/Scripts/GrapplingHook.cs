using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mousedir;

    public bool isHookActive;
    public bool isLineMax;

    void Start()
    {
        line.positionCount = 2;  //Line을 그리는 포지션의 수 2개로 설정
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position); //한점은 Player의 포지션, 한 점은 Hook의 포지션
        line.SetPosition(1, hook.position);
        // LineRenderer가 추가되어 있는 오브젝트에 위치와 상관없이
        // 월드 좌표를 기준으로 화면에 Line이 그려지게 됨.
        line.useWorldSpace = true; 

    }
    void Update()
    {
        //고리와 플레이어의 좌표가 변경되면 Line의 포지션 값이 변경하게 됨.
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if(Input.GetKeyDown(KeyCode.E) && !isHookActive)
        {
            // 마우스 포지션은 스크린을 기준으로 값을 반환하기에 월드 좌표로 바꿔주고,
            // 플레이어의 위치값을 빼주면 고리가 날아가야하는 방향의 벡터값을 알 수 있음.
            hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            isLineMax = false;
            hook.gameObject.SetActive(true);
        }

        if(isHookActive && !isLineMax)
        {
            // 고리가 날아가는것은 Translate함수를이용
            // 인자값으로 아까 구한 벡터값을 정규화시킨 값을 줌
            // 정규화 시 벡터의 방향은 유지한채 벡터의 길이를 1로 유지 가능
            hook.Translate(mousedir.normalized * Time.deltaTime * 15); 

            //고리가 날아가다가 플레이어와 거리가 5 이상 나게되면 다시 돌아옴
            if(Vector2.Distance(transform.position, hook.position)>5)
            {
                isLineMax = true;
            }
        }else if(isHookActive && !isLineMax)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position,hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }

        }
    }
}
