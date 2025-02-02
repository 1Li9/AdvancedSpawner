using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _beginPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private Transform _currentPoint;
    private float _currentPointChangeDistance = .2f;

    private void Awake()
    {
        transform.position = _beginPoint.position;
        _currentPoint = _endPoint;
    }

    private void Update() =>
        Move();

    private void Move()
    {
        if (Vector3.Distance(transform.position, _currentPoint.position) > _currentPointChangeDistance)
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, Time.deltaTime * _speed);
        else
            SelectNextPoint();
    }

    private void SelectNextPoint()
    {
        if (_currentPoint == _beginPoint)
            _currentPoint = _endPoint;
        else
            _currentPoint = _beginPoint;
    }
}
