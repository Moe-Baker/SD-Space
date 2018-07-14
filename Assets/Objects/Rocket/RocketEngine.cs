using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
    public class RocketEngine : MonoBehaviour, Rocket.IReference
    {
        public Rocket Rocket { get; protected set; }
        void References.Interface<Rocket>.Set(Rocket reference)
        {
            Rocket = reference;
        }

        public RocketFuel Fuel { get { return Rocket.Fuel; } }

        new public Rigidbody rigidbody { get { return Rocket.rigidbody; } }

        [SerializeField]
        protected float fuelUsage = 10f;
        public float FuelUsage { get { return fuelUsage; } }
        protected virtual void UseFuel(float rate)
        {
            Fuel.Value -= FuelUsage * Time.deltaTime;
        }
        protected virtual void UseFuel()
        {
            UseFuel(1f);
        }

        [SerializeField]
        protected PowerData power = new PowerData(20f, 40f);
        public PowerData Power { get { return power; } }
        [Serializable]
        public struct PowerData
        {
            [SerializeField]
            float vertical;
            public float Vertical { get { return vertical; } }

            [SerializeField]
            float angular;
            public float Angular { get { return angular; } }

            public PowerData(float vertical, float angular)
            {
                this.vertical = vertical;
                this.angular = angular;
            }
        }

        public virtual void Accelerate(float throttle)
        {
            if (throttle == 0f) return;

            if(Fuel.Empty)
            {

            }
            else
            {
                UseFuel(throttle);

                rigidbody.AddForce(Rocket.transform.up * power.Vertical * throttle, ForceMode.Acceleration);
            }
        }

        public virtual void Lean(float direction)
        {
            if (Fuel.Empty)
            {

            }
            else
            {
                UseFuel();

                rigidbody.AddTorque(-Rocket.transform.forward * direction * power.Angular, ForceMode.Acceleration);
            }
        }
    }
}