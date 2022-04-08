using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private int _defHp;
    private bool _isDie = false;

    private void OnEnable()
    {
        _defHp = HP;
    }

    public void TakeDamage(int damage)
    {
        
        HP -= damage;
        ProjectDelegates.OnTakeDamage?.Invoke((float)HP/_defHp, transform);
        if (HP <= 0 && !_isDie)
        {
            GetComponent<Animator>().enabled = false;
            _isDie = true;
            ProjectDelegates.OnEnemyDie?.Invoke();
        }
    }

}
