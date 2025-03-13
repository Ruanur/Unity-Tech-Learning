using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class ClickMove : MonoBehaviour
{
    private new Camera camera;
    private NavMeshAgent agent;
    private Animator anim;

    private bool isMove;
    private Vector3 destination;
    [SerializeField] private Transform character;

    private void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        anim = character.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                SetDestination(hit.point);
                isMove = true;
            }
        }
        LookMoveDirection();
    }

    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        
    }

    private void LookMoveDirection()
    {
        if (agent.velocity.magnitude == 0f)
        {
            isMove = false;
            anim.SetBool("Move", false);
            return;
        }
        if (isMove)
        {
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            character.transform.forward = dir;
            anim.SetBool("Move", true);
            //transform.position += dir.normalized * Time.deltaTime * 5f;
        }

    }
}
