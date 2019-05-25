using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ObserverPattern
{
    public class TankScript : MonoBehaviour
    {
        private float health = 100;

        public event Action<float> DamageEvent;

        private void Start()
        {
            DamageEvent?.Invoke(health);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Damage();
            }
        }

        void Damage()
        {
            health -= 2;
            DamageEvent?.Invoke(health);
        }

    }
}