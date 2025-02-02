using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    public Target Target { get; set; }

    private void Update() =>
        Move();

    private void Move()
    {
        Vector3 direction = Target.transform.position - transform.position;
        direction = direction.normalized;

        transform.forward = direction;
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
