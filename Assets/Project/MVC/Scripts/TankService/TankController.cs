using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace TankSystem
{
    public class TankController
    {
        ServiceLocator serviceLocator;
        TankView tankView;

        public TankController(ServiceLocator serviceLocator, GameObject tankPrefab, Vector2 spawnPos)
        {
            this.serviceLocator = serviceLocator;
            GameObject tank = Object.Instantiate(tankPrefab);
            tankView = tank.GetComponent<TankView>();
            tankView.SetTankController(this);
        }

        public void FireMethod(Vector2 position)
        {
            serviceLocator.FireEventInvoke(position);
        }

    }
}