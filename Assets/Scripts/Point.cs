using UnityEngine;

public class Point : MonoBehaviour
{
     
    [SerializeField] private Player _player;
    private int _countEnemy;
    private void Start()
    {
        _countEnemy = transform.childCount ;
        for(int i =0;i<_countEnemy;i++){
            transform.GetChild(i).GetComponent<Enemy>().Dead += EnemyIsDead;
        }
    }

    private void EnemyIsDead(){
        if(_countEnemy > 0)
            _countEnemy--;
        if (_countEnemy <= 0){
            _player.SetBehaviorMove();
            this.gameObject.SetActive(false);
        }
    }
}
