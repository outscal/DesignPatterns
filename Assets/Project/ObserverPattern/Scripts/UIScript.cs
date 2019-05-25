using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    public class UIScript : MonoBehaviour
    {
        [SerializeField] private Text healthText;

        [SerializeField] private TankScript tankScript;
        // Start is called before the first frame update

        private void OnEnable()
        {
            tankScript.DamageEvent += UpdateHealth;
        }

        private void OnDisable()
        {
            tankScript.DamageEvent -= UpdateHealth;
        }

        void UpdateHealth(float health)
        {
            healthText.text = "Health: " + health;
        }
    }
}