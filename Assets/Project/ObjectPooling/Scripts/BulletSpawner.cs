﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class BulletSpawner : MonoBehaviour
    {
        public static BulletSpawner instance;

        [SerializeField] private GameObject bulletPrefab;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public GameObject SpawnBullet()
        {
            GameObject bullet = Instantiate(bulletPrefab);

            return bullet;
        }
    }
}