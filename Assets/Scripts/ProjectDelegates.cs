using UnityEngine;

public class ProjectDelegates : MonoBehaviour
{
    public delegate void CompletePlace(bool _isFinish);
    public static CompletePlace OnCompletePlace;

    public delegate void EnemyDie();
    public static EnemyDie OnEnemyDie;

    public delegate void TakeDamage(float damage, Transform pos);
    public static TakeDamage OnTakeDamage;

}
