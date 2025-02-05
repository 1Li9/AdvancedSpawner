using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Color _gizmosColor;
    [SerializeField] private float _gizmosHeight;

    [SerializeField] private Mover _prefab;
    [SerializeField] private Target _target;
    [SerializeField] private float _radius;
    [SerializeField] private float _timePeriod;
    [SerializeField] private float _yOffset;

    private void Start() =>
        StartCoroutine(Timer.DoActionRepeating(() => Spawn(), _timePeriod));

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1, _gizmosHeight, 1));
        Gizmos.DrawSphere(Vector3.zero, _radius);
        Gizmos.matrix = Matrix4x4.identity;
    }

    private void Spawn()
    {
        Vector2 positionOffset = Random.insideUnitCircle * _radius;
        Vector3 position = transform.position + new Vector3(positionOffset.x, 0, positionOffset.y) + Vector3.up * _yOffset;

        _prefab.transform.SetPositionAndRotation(position, Quaternion.identity);
        Instantiate(_prefab).SetTarget(_target);
    }
}
