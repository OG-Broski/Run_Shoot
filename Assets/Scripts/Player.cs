using System;
using System.Collections.Generic;
using UnityEngine;
    public class Player : MonoBehaviour
    {

       private Dictionary<Type, IPlayerBehavior> _behaviorMap;
       private IPlayerBehavior _behaviorCurrent;

       private void Start()
       {
           this.InitBehaviors();
            this.SetBehaviorByDefault();
      
       }

       private void Update()
       {
           _behaviorCurrent.Update();
       }

        private void InitBehaviors(){
            this._behaviorMap = new Dictionary<Type, IPlayerBehavior>();
            this._behaviorMap[typeof(MoveState)] =new MoveState();
            this._behaviorMap[typeof(IdleState)] =new IdleState();
            this._behaviorMap[typeof(ShootingState)] =new ShootingState();
        }
        private void SetBehavior(IPlayerBehavior _newBehavior){  
            if(this._behaviorCurrent !=null){
                this._behaviorCurrent.Exit();
            }
                this._behaviorCurrent = _newBehavior;
                this._behaviorCurrent.Enter(this.gameObject);

        }

        private void SetBehaviorByDefault(){
            this.SetBehaviorIdle();
        }

        private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior{
            var _type = typeof(T);
            return this._behaviorMap[_type];
        }

        public void SetBehaviorIdle(){
            var _behavior = this.GetBehavior<IdleState>();
            this.SetBehavior(_behavior);
        }
        public void SetBehaviorMove(){
            var _behavior = this.GetBehavior<MoveState>();
            this.SetBehavior(_behavior);
        }


        public void SetBehaviorShoot(){
            var _behavior = this.GetBehavior<ShootingState>();
            this.SetBehavior(_behavior);
        }

    
    }
    


