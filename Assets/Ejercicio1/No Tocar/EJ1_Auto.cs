using System;
using UnityEngine;

namespace Ejercicio_1
{
    public class EJ1_Auto : MonoBehaviour
    {
        public WheelCollider frontLeftWheel;
        public WheelCollider frontRightWheel;
        public GameObject saveBlock;
        public Rigidbody skeleton;
        public Animator person;
        
        [Header("Popups")]
        public GameObject winPopup;
        public GameObject missRigidbody;
        public GameObject missScript;
        public GameObject missBoxCollider;
        public GameObject missSkeletonComponent;

        private float speed = 200;
        
        private void Start()
        {
            speed = 200;
            winPopup.SetActive(false);
        }

        void FixedUpdate()
        {
            frontLeftWheel.motorTorque = speed;
            frontRightWheel.motorTorque = speed;
            
            missRigidbody.SetActive(!saveBlock.GetComponent<Rigidbody>());
            missScript.SetActive(!saveBlock.GetComponent<EJ1_BloqueSalvador>());
            missBoxCollider.SetActive(skeleton != null && !skeleton.GetComponent<CapsuleCollider>());
            missSkeletonComponent.SetActive(skeleton != null && !skeleton.GetComponent<EJ1_Esqueleto>());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<EJ1_Esqueleto>())
                Win();
            else if (collision.gameObject.GetComponent<CapsuleCollider>())
            {
                speed = 0;
                Destroy(GetComponent<Rigidbody>());
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
            }
            
        }

        private void Win()
        {
            winPopup.SetActive(true);
            skeleton.AddForce(Vector3.right * 30, ForceMode.Impulse);
            person.SetTrigger("win");
        }
    }
}
