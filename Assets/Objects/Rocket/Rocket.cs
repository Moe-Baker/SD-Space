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
    [RequireComponent(typeof(Rigidbody))]
	public class Rocket : MonoBehaviour
	{
        new public Rigidbody rigidbody { get; protected set; }
        protected virtual void InitRigidbody()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public RocketFuel Fuel { get; protected set; }
        protected virtual void InitFuel()
        {
            Fuel = Dependency.Find<RocketFuel>(gameObject);
        }

        public RocketEngine Engine { get; protected set; }
        protected virtual void InitEngine()
        {
            Engine = Dependency.Find<RocketEngine>(gameObject);
        }

        protected virtual void Awake()
        {
            InitRigidbody();

            InitFuel();
            InitEngine();

            References.Set(this);
        }

        public interface IReference : References.Interface<Rocket>
        {

        }
	}
}