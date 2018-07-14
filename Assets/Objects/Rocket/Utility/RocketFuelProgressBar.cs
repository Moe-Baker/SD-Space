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
    [RequireComponent(typeof(ProgressBar))]
	public class RocketFuelProgressBar : MonoBehaviour
	{
        [SerializeField]
        protected Rocket rocket;
        public Rocket Rocket { get { return rocket; } }

        ProgressBar bar;

        protected virtual void Start()
        {
            bar = GetComponent<ProgressBar>();

            rocket.Fuel.OnStateChange += OnStateChanged;

            UpdateState();
        }

        protected virtual void UpdateState()
        {
            bar.Value = rocket.Fuel.Rate;
        }

        protected virtual void OnStateChanged()
        {
            UpdateState();
        }
    }
}