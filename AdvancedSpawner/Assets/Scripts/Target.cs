using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private Transform _currentPoint;
    private int _currentPointIndex = 0;
    private readonly float _pointChangeDistance = .2f;

    private void Awake()
    {
        _currentPoint = _points[_currentPointIndex];
        transform.position = _currentPoint.position;
    }

    private void Update() =>
        Move();

    private void Move()
    {
        float squareDistance = (transform.position - _currentPoint.position).sqrMagnitude;

        if (squareDistance > _pointChangeDistance)
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, Time.deltaTime * _speed);
        else
            SelectNextPoint();
    }

    private void SelectNextPoint()
    {
        if (_currentPointIndex + 1 < _points.Length)
            _currentPointIndex++;
        else
            _currentPointIndex = 0;

        _currentPoint = _points[_currentPointIndex];
    }
}
