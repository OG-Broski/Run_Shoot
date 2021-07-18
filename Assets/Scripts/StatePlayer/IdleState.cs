using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerBehavior
{
    public void Enter(GameObject player)
    {
     
    }

    public void Exit()
    {
         Debug.Log("Player IDLE Exit");
    }

    public void FixedUpdate()
    {
        
    }

    public void Update()
    {
       Debug.Log("Player IDLE Update");
    }
}
