using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField, Range(0,10)] private float speed;
    
    private int currentWaypointIndex = 0;
    private bool isReturning = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0) 
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
        
        switch (transform.position)
        {
            case var pos when pos == waypoints[0].position && !isReturning:
                currentWaypointIndex = 1;
                break;
            case var pos when pos == waypoints[1].position && !isReturning:
                currentWaypointIndex = 2;
                isReturning = true;
                break;
            case var pos when pos == waypoints[2].position && isReturning:
                currentWaypointIndex = 1;
                break;
            case var pos when pos == waypoints[1].position && isReturning:
                currentWaypointIndex = 0;
                isReturning = false;
                break;
        }
    }
}
