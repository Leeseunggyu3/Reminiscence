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
        line.positionCount = 2;  //Line�� �׸��� �������� �� 2���� ����
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position); //������ Player�� ������, �� ���� Hook�� ������
        line.SetPosition(1, hook.position);
        // LineRenderer�� �߰��Ǿ� �ִ� ������Ʈ�� ��ġ�� �������
        // ���� ��ǥ�� �������� ȭ�鿡 Line�� �׷����� ��.
        line.useWorldSpace = true; 

    }
    void Update()
    {
        //���� �÷��̾��� ��ǥ�� ����Ǹ� Line�� ������ ���� �����ϰ� ��.
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if(Input.GetKeyDown(KeyCode.E) && !isHookActive)
        {
            // ���콺 �������� ��ũ���� �������� ���� ��ȯ�ϱ⿡ ���� ��ǥ�� �ٲ��ְ�,
            // �÷��̾��� ��ġ���� ���ָ� ���� ���ư����ϴ� ������ ���Ͱ��� �� �� ����.
            hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            isLineMax = false;
            hook.gameObject.SetActive(true);
        }

        if(isHookActive && !isLineMax)
        {
            // ���� ���ư��°��� Translate�Լ����̿�
            // ���ڰ����� �Ʊ� ���� ���Ͱ��� ����ȭ��Ų ���� ��
            // ����ȭ �� ������ ������ ������ä ������ ���̸� 1�� ���� ����
            hook.Translate(mousedir.normalized * Time.deltaTime * 15); 

            //���� ���ư��ٰ� �÷��̾�� �Ÿ��� 5 �̻� ���ԵǸ� �ٽ� ���ƿ�
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
