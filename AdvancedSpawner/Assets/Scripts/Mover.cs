using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Target _target;

    private void Update() =>
        Move();

    public void SetTarget(Target target) =>
        _target = target;

    private void Move()
    {
        Vector3 direction = _target.transform.position - transform.position;
        direction = direction.normalized;

        transform.forward = direction;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
    }
}
