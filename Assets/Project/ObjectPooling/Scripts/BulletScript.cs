using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D myBody;

        [SerializeField] private float force = 5f, destroyTime = 1f;

        public void FireBullet(Vector3 direction)
        {
            myBody.AddForce(direction * force, ForceMode2D.Impulse);

            //Destroy(gameObject, destroyTime);
            Invoke("DeactivateGameobject", destroyTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }

        private void DeactivateGameobject()
        {
            gameObject.SetActive(false);
        }

    }
}