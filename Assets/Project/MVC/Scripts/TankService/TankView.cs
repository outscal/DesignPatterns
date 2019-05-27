using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankSystem
{
    public class TankView : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.25f;
        [SerializeField] private Transform[] bulletPos;

        private float currentFireRate;
        private bool shooting = false;
        private TankController tankController;

        public void SetTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        private void Update()
        {
            #region Not Important
            if (Input.GetMouseButtonDown(0) && shooting == false)
            {
                if (currentFireRate <= 0)
                    shooting = true;
                //currentFireRate = 0;
            }
            else if (Input.GetMouseButtonUp(0) && shooting == true)
            {
                shooting = false;
            }
            #endregion

            if(currentFireRate > 0) currentFireRate -= Time.deltaTime;

            if (shooting)
            {
                if (currentFireRate <= 0)
                {
                    for (int i = 0; i < bulletPos.Length; i++)
                    {
                        tankController.FireMethod(bulletPos[i].position);
                    }
                    
                    currentFireRate = fireRate;
                }
            }
        }

    }
}