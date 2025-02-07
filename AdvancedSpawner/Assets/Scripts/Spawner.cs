using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private SpawnerPoint[] _points;
    [SerializeField] private float _timePeriod;

    private void Start() =>
        _timer.DoActionRepeating(() => Spawn(), _timePeriod);

    private void Spawn()
    {
        foreach (SpawnerPoint point in _points)
            point.Spawn();
    }
}
