using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SingletonPattern
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankController : MonoBehaviour
    {
        #region Not Important
        [SerializeField] private float moveSpeed, fireRate = 0.25f;
        [SerializeField] private Transform spriteTransform;
        [SerializeField] private Transform bulletSpawnPos;

        private float horizontalVal, currentFireRate;

        [SerializeField] private Rigidbody2D myBody;

        private Vector3 direction = Vector3.right;
        private bool shooting = false;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            currentFireRate = 0;
        }

        // Update is called once per frame
        void Update()
        {
            #region Not Important
            horizontalVal = Input.GetAxis("Horizontal");
            GetDirection();
            if (Input.GetMouseButtonDown(0) && shooting == false)
            {
                shooting = true;
                currentFireRate = 0;
            }
            else if (Input.GetMouseButtonUp(0) && shooting == true)
            {
                shooting = false;
            }
            #endregion

            if (shooting)
            {
                currentFireRate -= Time.deltaTime;
                if (currentFireRate <= 0)
                {
                    FireMethod();
                    currentFireRate = fireRate;
                }
            }

        }

        #region Not Important
        private void FixedUpdate()
        {
            if (horizontalVal != 0)
            {
                Vector2 newPos = transform.position + Vector3.right * horizontalVal * moveSpeed * Time.fixedDeltaTime;
                myBody.MovePosition(newPos);
            }

        }

        void GetDirection()
        {
            if (horizontalVal > 0 && direction == Vector3.left)
            {
                direction = Vector3.right;
                spriteTransform.localScale = new Vector3(1, 1, 1);
            }
            if (horizontalVal < 0 && direction == Vector3.right)
            {
                direction = Vector3.left;
                spriteTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
        #endregion

        void FireMethod()
        {
            GameObject bullet = BulletSpawner.instance.SpawnBullet();
            bullet.transform.position = bulletSpawnPos.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.GetComponent<BulletScript>().FireBullet(direction);
        }

    }
}