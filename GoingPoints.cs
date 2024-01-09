using UnityEngine;

public class GoingPoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _parentPoint;

    private Transform[] _childrenPoints;
    private int _pointNumber = 0;

    private void Start()
    {
        _childrenPoints = new Transform[_parentPoint.childCount];

        for (int i = 0; i < _childrenPoints.Length; i++)
            _childrenPoints[i] = _parentPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform pointByNumber = _childrenPoints[_pointNumber];

        transform.position = Vector3.MoveTowards(transform.position, pointByNumber.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumber.position)
            MoveToNextPoint();
    }
    private Vector3 MoveToNextPoint()
    {
        _pointNumber++;

        if (_pointNumber == _childrenPoints.Length)
            _pointNumber = 0;

        Vector3 currentPointPosition = _childrenPoints[_pointNumber].transform.position;
        transform.forward = currentPointPosition - transform.position;

        return currentPointPosition;
    }
}