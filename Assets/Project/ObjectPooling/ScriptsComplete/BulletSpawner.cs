using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling_Complete
{
    public class BulletSpawner : MonoBehaviour
    {
        public static BulletSpawner instance;

        [SerializeField] private GameObject bulletPrefab;

        private Stack<GameObject> unUsedBulletList;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            unUsedBulletList = new Stack<GameObject>();

            for (int i = 0; i < 4; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform);
                unUsedBulletList.Push(bullet);
                bullet.SetActive(false);
            }
        }

        public GameObject SpawnBullet()
        {
            GameObject bullet = null;

            if (unUsedBulletList.Count > 0)
                bullet = unUsedBulletList.Pop();

            if (bullet == null)
            {
                bullet = Instantiate(bulletPrefab, transform);
                unUsedBulletList.Push(bullet);
                bullet.SetActive(false);
            }

            return bullet;
        }

        public void AddToStack(GameObject bullet)
        {
            unUsedBulletList.Push(bullet);
            bullet.SetActive(false);
        }
    }
}