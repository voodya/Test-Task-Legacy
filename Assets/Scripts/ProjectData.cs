using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/solutoin")]

[Serializable]
public class ProjectData : ScriptableObject
{
    [SerializeField] public GameObject _player;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public CinemachineVirtualCamera _zoomCamera;
    [SerializeField] public int _bulletImpulse = 15;
    [SerializeField] public float _rotationSpeed = 2;
    public  Animator _animator;
    public bool _walk = false;

    public CinemachineVirtualCamera GetCamera()
    {
        if(_zoomCamera == null)
        {
            _zoomCamera = GameObject.FindGameObjectWithTag("ZoomCamera").GetComponent<CinemachineVirtualCamera>(); 
        }
        
        return _zoomCamera;
    }
    public GameObject GetPlayer()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        _animator = _player.GetComponent<Animator>();
        return _player;
    }

}
