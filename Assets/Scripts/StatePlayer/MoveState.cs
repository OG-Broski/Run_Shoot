using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class MoveState : IPlayerBehavior
{
    [SerializeField] private int _currentIndex = -1;
    private Player _player;
    private PlayerData _playerData;

    private NavMeshAgent _navMeshAgent;

    [SerializeField] private int _minDistan = 3;
    private bool _canGo = false;
   public void Enter(GameObject player)
    {
        
        if(_navMeshAgent == null | _playerData ==null|_player==null){
            _navMeshAgent= player.GetComponent<NavMeshAgent>();
            _player=player.GetComponent<Player>();
            _playerData = PlayerData.singleton;
        }
        _playerData.animator.SetTrigger("SetMove");
        SetToPoint();

        Debug.Log("Player MOve Enter");
    }
    public void Update()
    {
        if(_navMeshAgent.remainingDistance > _minDistan){
            _canGo=true;
        }
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _canGo){
            _player.SetBehaviorShoot();
        }
        Debug.Log("Player MOve Update");
    }

    public void FixedUpdate()
    {

    }
     private void SetToPoint(){
         _currentIndex++;
        if(_currentIndex >_playerData.lastPoint){
            SceneManager.LoadScene(0);
        }
        else{
        _navMeshAgent.SetDestination( _playerData.path.GetChild(_currentIndex).transform.position);
         }
    }        
     

    public void Exit()
    {   _canGo=false;
         Debug.Log("Player MOve Exit");
    }
}

