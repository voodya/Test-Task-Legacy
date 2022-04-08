using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections;

public class ChangeStateLogic : MonoBehaviour
{
    [SerializeField] private ProjectData _data;
    [SerializeField] private List<GameObject> _places;
    [SerializeField] private GameObject _button;
    private NavMeshAgent _player;
    private int _index = -1;

    #region Delegates
    private void OnEnable()
    {
        if (_data._player == null) _data._player = _data.GetPlayer();
        _player = _data._player.GetComponent<NavMeshAgent>();
        ProjectDelegates.OnCompletePlace += PlaceCompleted;
    }
    private void OnDisable()
    {
        ProjectDelegates.OnCompletePlace -= PlaceCompleted;
    }
    #endregion
    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlaceCompleted(bool _isFinish)
    {
        if (_isFinish) StartCoroutine(EndGame());
        ActivateNextPlace();
    }
    public void ActivateNextPlace()
    {
        _data._walk = true;
        _button.SetActive(false);
        _data._animator.SetBool("Run", true);
        if(_index>=0) _places[_index].SetActive(false);
        _index++;
        _places[_index].SetActive(true);
        _player.SetDestination(_places[_index].transform.position);
    }

}
