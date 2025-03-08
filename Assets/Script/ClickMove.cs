using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class ClickMove : MonoBehaviour
{
    private new Camera camera;

    private bool isMove;
    private Vector3 destination;
    [SerializeField] private Transform character;

    private void Awake()
    {
        camera = Camera.main;
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

        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
    }

    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }

            var dir = destination - transform.position;
            character.transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }
}
