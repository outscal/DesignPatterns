using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankSystem
{
    public interface ITankService
    {
        void SpawnTank(Vector2 spawnPos);
    }
}