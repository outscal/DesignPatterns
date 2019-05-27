using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace BulletSystem
{
    public class BulletService : IBulletService
    {
        private GameObject bulletPrefab;
        private List<BulletController> bulletControllerList;

        public BulletService(ServiceLocator serviceLocator, GameObject bulletPrefab)
        {
            this.bulletPrefab = bulletPrefab;
            bulletControllerList = new List<BulletController>();
            serviceLocator.FireEvent += GetBullet;
        }

        public void DestroyBullet(BulletController bulletController)
        {
            //bulletController.Destroy();
            bulletControllerList.Remove(bulletController);
            bulletController = null;
        }

        public void GetBullet(Vector2 spawnPos)
        {
            BulletController bulletController = new BulletController(bulletPrefab, this);
            bulletController.GetBullet.gameObject.transform.position = spawnPos;
        }
    }
}