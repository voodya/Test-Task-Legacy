using UnityEngine;

public class TakeDamageLogic : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _enemy.TakeDamage(_damage);
        }
    }
}
