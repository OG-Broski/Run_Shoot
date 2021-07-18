using UnityEngine;
using System;


public class Enemy : MonoBehaviour{

    public event Action ToEnablePhysic;
    public event Action Dead;
    [SerializeField] private int _health;
    [SerializeField] private Point  _point;
    
  


    private void Start()
    {
        _point = transform.parent.GetComponent<Point>();        
    }

    public void TakeDamage(int damage){
        if(_health > 0){
            _health -=damage;
        }
        if(_health <=0){
            if(Dead != null){
                ToEnablePhysic.Invoke();
            
            Dead.Invoke();
           this.enabled = false;
            }
        }
    }
}

