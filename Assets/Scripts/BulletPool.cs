using UnityEngine;

public class BulletPool : MonoBehaviour
{

   [SerializeField] private int _poolCount = 5;
   [SerializeField] private bool _autoExpand = false;

   [SerializeField] private Bullet _bulletPrefab;

   private PoolMono<Bullet> _pool;


   private void Start()
   {
       this._pool = new PoolMono<Bullet>(this._bulletPrefab , this._poolCount,this.transform);
       this._pool.autoExpand = this._autoExpand;
   }

   public void Shoot(){
       var bullet =this._pool.GetFreeElement();
        bullet.Shoot(PlayerData.singleton.gun);
   }
}
