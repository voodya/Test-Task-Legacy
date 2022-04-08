using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Image _hpBar;

    private void Start()
    {
        _camera = Camera.main;
    }
    private void OnEnable()
    {
        ProjectDelegates.OnTakeDamage += SetHP;
    }
    private void OnDisable()
    {
        ProjectDelegates.OnTakeDamage -= SetHP;
    }
    public void SetHP(float Damage, Transform pos)
    {
        Vector3 _target = pos.position + new Vector3(0, 17.8f * pos.localScale.y*2, 0);
        _hpBar.gameObject.transform.position = _camera.WorldToScreenPoint(_target);
        _hpBar.fillAmount = Damage;
    }

}
