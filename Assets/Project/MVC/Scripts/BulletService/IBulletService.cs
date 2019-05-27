using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public interface IBulletService
    {
        void GetBullet(Vector2 spawnPos);
        void DestroyBullet(BulletController bulletController);
    }
}