using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private TankScript tankScript;

        #region NotImportant
        // Transform of the camera to shake. Grabs the gameObject's transform
        // if null.
        public Transform camTransform;

        // How long the object should shake for.
        public float shakeDuration = 0f;

        // Amplitude of the shake. A larger value shakes the camera harder.
        public float shakeAmount = 0.7f;
        public float decreaseFactor = 1.0f;

        private float currentShakeTime;
        Vector3 originalPos;
        #endregion

        private void OnEnable()
        {
            tankScript.DamageEvent += ShaheCamera;
            originalPos = camTransform.localPosition;
        }

        private void OnDisable()
        {
            tankScript.DamageEvent -= ShaheCamera;
        }

        #region NotImportant
        void Awake()
        {
            currentShakeTime = shakeDuration;
            if (camTransform == null)
            {
                camTransform = GetComponent(typeof(Transform)) as Transform;
            }
        }

        void Update()
        {
            if (currentShakeTime > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                currentShakeTime -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                currentShakeTime = 0f;
                camTransform.localPosition = originalPos;
            }
        }
        #endregion

        void ShaheCamera(float noUse)
        {
            currentShakeTime = shakeDuration;
        }
    }
}