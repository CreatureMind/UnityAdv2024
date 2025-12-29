using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out var hit);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            agent.SetDestination(hit.point);
    }
}
