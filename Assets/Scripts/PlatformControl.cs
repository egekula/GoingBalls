using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;

    private int _currentWaypointIndex = 0;

    [SerializeField] private float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].transform.position) < 1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypointIndex].transform.position,
            speed * Time.deltaTime);
    }
}
