using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public class BulletController
    {
        private BulletView bulletView;
        private BulletService bulletService;

        public BulletView GetBullet { get { return bulletView; } }

        public BulletController(GameObject bulletObj, BulletService bulletService)
        {
            this.bulletService = bulletService;
            GameObject bullet = Object.Instantiate(bulletObj);
            bulletView = bullet.GetComponent<BulletView>();
            bulletView.BulletController = this;
            bulletView.FireBullet(Vector3.up);
        }

        public void Destroy()
        {
            bulletService.DestroyBullet(this);
            Object.Destroy(bulletView.gameObject);
        }

    }
}