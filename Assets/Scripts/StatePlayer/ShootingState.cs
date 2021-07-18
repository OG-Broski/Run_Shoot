using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : IPlayerBehavior
{
    private Player _player;

    private PlayerData _playerData;

    public void Enter(GameObject player)
    {
        if(_player == null | _playerData ==null){
            _player= player.GetComponent<Player>();
            _playerData = PlayerData.singleton;
        }
        Debug.Log("Enter SHOOTING state");
        _playerData.animator.SetTrigger("SetShooting");
        _playerData.gunModels.gameObject.SetActive(true);
    }

    public void Exit()
    {
       Debug.Log("EXIT SHOOTING state");
       _playerData.gunModels.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            this.Shoot();
        }
         Debug.Log("UPDATE SHOOTING state");
    }
    public void Shoot(){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition -Vector3.up);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit)){

                    _playerData.gun.transform.LookAt(hit.point);
                    _player.transform.LookAt(hit.point);
                }
                else{
                    _playerData.gun.transform.LookAt(ray.GetPoint(_playerData.distansShootRay));
                    _player.transform.LookAt(ray.GetPoint(_playerData.distansShootRay));

                }
                _playerData.bulletPool.Shoot();
        }
    
}

