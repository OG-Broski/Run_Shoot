using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysical : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodys;

    private void Awake()
    {
        for(int i = 0; i < _allRigidbodys.Length;i++){
            _allRigidbodys[i].isKinematic = true;
        }
    }
    private void Start()
    {
         if(transform.parent.TryGetComponent(typeof(Enemy), out Component component)){
            transform.parent.GetComponent<Enemy>().ToEnablePhysic += EnablePhysic;
         }
    }

    private void EnablePhysic(){
        for(int i = 0; i < _allRigidbodys.Length;i++){
            _allRigidbodys[i].isKinematic = false;
        }
        _animator.enabled = false;
    }
}
