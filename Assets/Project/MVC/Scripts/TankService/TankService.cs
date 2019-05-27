using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace TankSystem
{
    public class TankService : ITankService
    {
        ServiceLocator serviceLocator;

        private GameObject tankPrefab;
        private TankController tankController;

        public TankService(ServiceLocator serviceLocator, GameObject tankPrefab)
        {
            this.serviceLocator = serviceLocator;
            this.tankPrefab = tankPrefab;
            SpawnTank(new Vector2(0, -2f));
        }

        public void SpawnTank(Vector2 spawnPos)
        {
            TankController tankController = new TankController(serviceLocator, tankPrefab, spawnPos);
        }

    }
}