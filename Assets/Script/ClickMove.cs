using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class ClickMove : MonoBehaviour
{
    //���콺�� ��ġ�� ���� ��ǥ��� ǥ���ϱ� ���� ����
    private new Camera camera;
    private NavMeshAgent agent;
    private Animator anim;

    //ĳ���Ͱ� �����̰� �ִ��� Ȯ��
    private bool isMove;
    //ĳ���� ��ǥ ��ġ ���
    private Vector3 destination;

    private void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        LookMoveDirection();
    }

    //Ŭ������ ã�Ƴ� ���콺�� ��ġ�� ���� �� �̵��� �����ϰ� �ϴ� ���� ����, Nav �ý��� Ȱ��
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    //�÷��̾� ȸ�� �Լ�
    private void LookMoveDirection()
    {
        //�ӵ��� 0�� ��, �̵��� ����
        if (agent.velocity.magnitude == 0f)
        {
            isMove = false;
            anim.SetBool("Move", false);
            return;
        }

        //�̵� ��, ���� ����
        if (isMove)
        {
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            transform.forward = dir;
            anim.SetBool("Move", true);
            //transform.position += dir.normalized * Time.deltaTime * 5f;
        }

    }
}
