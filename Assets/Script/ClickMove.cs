using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class ClickMove : MonoBehaviour
{
    //마우스의 위치를 월드 좌표계로 표시하기 위해 선언
    private new Camera camera;
    private NavMeshAgent agent;
    private Animator anim;

    //캐릭터가 움직이고 있는지 확인
    private bool isMove;
    //캐릭터 목표 위치 기억
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

    //클릭으로 찾아낸 마우스의 위치를 저장 후 이동을 시작하게 하는 역할 수행, Nav 시스템 활용
    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
    }

    //플레이어 회전 함수
    private void LookMoveDirection()
    {
        //속도가 0일 때, 이동을 중지
        if (agent.velocity.magnitude == 0f)
        {
            isMove = false;
            anim.SetBool("Move", false);
            return;
        }

        //이동 중, 방향 설정
        if (isMove)
        {
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            transform.forward = dir;
            anim.SetBool("Move", true);
            //transform.position += dir.normalized * Time.deltaTime * 5f;
        }

    }
}
