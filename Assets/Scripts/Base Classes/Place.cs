using UnityEngine;
using UnityEngine.AI;


public class Place : MonoBehaviour
{
    [SerializeField] private ProjectData _data;
    [SerializeField] private Transform _targetEnemys;
    [SerializeField] private bool _isFinish;
    [SerializeField] private int _enemyCount;
    private NavMeshAgent _agent;

    #region Delegates
    private void OnEnable()
    {
        if (_data._zoomCamera == null) _data._zoomCamera = _data.GetCamera();
        _agent = _data._player.GetComponent<NavMeshAgent>();
        ProjectDelegates.OnEnemyDie += EnemyDie;
    }
    private void OnDisable()
    {
        ProjectDelegates.OnEnemyDie -= EnemyDie;
    }
    #endregion

    #region triggers
    private void OnTriggerEnter(Collider other)
    {
        _data._walk = false;
        _data._animator.SetBool("Run", false);
        _agent.isStopped = true;
        _data._zoomCamera.Priority = 11;
    }

    private void OnTriggerStay(Collider other)
    {
        if(_enemyCount != 0) Look(_targetEnemys.position, _data._rotationSpeed);
    }

    #endregion

    public void Look(Vector3 point, float speed)
    {
        var direction = (point - _data._player.transform.position).normalized;
        direction.y = 0f;
        _data._player.transform.rotation = Quaternion.RotateTowards(_data._player.transform.rotation, Quaternion.LookRotation(direction), speed);
    }

    public void EnemyDie()
    {
        _enemyCount--;
        if (_enemyCount <= 0) Completed();
    }

    public void Completed()
    {
        _data._zoomCamera.Priority = 9;
        _agent.isStopped = false;
        ProjectDelegates.OnCompletePlace?.Invoke(_isFinish);
    }
}
