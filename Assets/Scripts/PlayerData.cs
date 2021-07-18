using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData singleton {get;private set;}

        [SerializeField] private Transform _path;
        public Transform path => _path;
        public int lastPoint => _path.childCount - 1;
        [SerializeField] private Transform  _gun;
        public Transform gun => _gun;
        [SerializeField] private Transform  _gunModels;
        public Transform gunModels => _gunModels;
        [SerializeField] private BulletPool  _bulletPool;
        public BulletPool bulletPool => _bulletPool;
         [SerializeField] private float _distansShootRay;
         public float distansShootRay => _distansShootRay;

         [SerializeField] private Animator _animator;
         public Animator animator =>_animator;

       



   private void Awake()
   {
       singleton = this;
   }
}

