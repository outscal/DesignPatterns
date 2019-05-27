using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletSystem;
using TankSystem;
using System;

namespace Common
{
    public class ServiceLocator : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject tankPrefab;

        public event Action<Vector2> FireEvent;

        private IBulletService bulletService;
        private ITankService tankService;

        public void Start()
        {
            bulletService = new BulletService(this, bulletPrefab);
            tankService = new TankService(this, tankPrefab);
        }

        public void FireEventInvoke(Vector2 positions)
        {
            FireEvent?.Invoke(positions);
        }


    }
}