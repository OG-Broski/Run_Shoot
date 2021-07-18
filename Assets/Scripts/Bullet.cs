using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private int _damage = 50;
    [SerializeField] private float _bulletVelocity = 20f;

    private Rigidbody _rigidbody;

    private void OnEnable()
    {   
        _rigidbody =  GetComponent<Rigidbody>();
        this.StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeRoutine());
    }
    
    private IEnumerator LifeRoutine(){
        yield return new WaitForSecondsRealtime(this._lifeTime);
        this.Deactivate();
    }


    private void Deactivate(){
        
        this.gameObject.SetActive(false);
    }

    public void Shoot(Transform gun){
        _rigidbody.velocity = Vector3.zero;
        this.transform.position =  gun.transform.position;
        _rigidbody.velocity = gun.transform.forward * _bulletVelocity;
    }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(typeof(Enemy), out Component component)){
                other.GetComponent<Enemy>().TakeDamage(_damage);
                this.gameObject.SetActive(false);
        }
    }
}
