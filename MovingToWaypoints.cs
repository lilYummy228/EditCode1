using UnityEngine;

public class MovingToWaypoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _parentWaypoint;

    private Transform[] _childrenWaypoints;
    private int _waypointNumber = 0;

    private void Start()
    {
        _childrenWaypoints = new Transform[_parentWaypoint.childCount];

        for (int i = 0; i < _childrenWaypoints.Length; i++)
            _childrenWaypoints[i] = _parentWaypoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform pointByNumber = _childrenWaypoints[_waypointNumber];

        transform.position = Vector3.MoveTowards(transform.position, pointByNumber.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumber.position)
            MoveToNextPoint();
    }
    private Vector3 MoveToNextPoint()
    {
        _waypointNumber++;

        if (_waypointNumber == _childrenWaypoints.Length)
            _waypointNumber = 0;

        Vector3 currentPointPosition = _childrenWaypoints[_waypointNumber].transform.position;
        transform.forward = currentPointPosition - transform.position;

        return currentPointPosition;
    }
}