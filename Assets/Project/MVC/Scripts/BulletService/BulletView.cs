using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D myBody;

        private BulletController bulletController;
        [SerializeField] private float force = 5f, destroyTime = 1f;

        public BulletController BulletController { set { bulletController = value; } get { return bulletController; } }

        public void FireBullet(Vector3 direction)
        {
            myBody.AddForce(direction * force, ForceMode2D.Impulse);
            Invoke("DestroyBullet", destroyTime);
        }

        private void DestroyBullet()
        {
            bulletController.Destroy();
        }

        public void GetDestroyed()
        {
            Destroy(gameObject);
        }


    }
}