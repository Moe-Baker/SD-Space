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
	public class RocketControlUI : MonoBehaviour
	{
        [SerializeField]
        protected Rocket rocket;
        public Rocket Rocket { get { return rocket; } }

        [SerializeField]
        protected Slider throttle;
        public Slider Throttle { get { return throttle; } }

        [SerializeField]
        protected ImageHoldEvent right;
        public ImageHoldEvent Right { get { return right; } }

        [SerializeField]
        protected ImageHoldEvent left;
        public ImageHoldEvent Left { get { return left; } }

        protected virtual void Start()
        {
            if (rocket == null)
                throw new NullReferenceException("rocket " + nameof(rocket) + " Set For " + nameof(RocketControlUI) + " on " + name);

            if (throttle == null)
                throw new NullReferenceException("No " + nameof(throttle) + " Set For " + nameof(RocketControlUI) + " on " + name);
            throttle.minValue = throttle.value = 0f;
            throttle.maxValue = 1f;

            if (right == null)
                throw new NullReferenceException("No " + nameof(right) + " Set For " + nameof(RocketControlUI) + " on " + name);
            right.Event.AddListener(() => rocket.Engine.Lean(1f));

            if (left == null)
                throw new NullReferenceException("No " + nameof(left) + " Set For " + nameof(RocketControlUI) + " on " + name);
            left.Event.AddListener(() => rocket.Engine.Lean(-1f));
        }

        protected virtual void Update()
        {
            ProcessAcceleration();
        }

        protected virtual void ProcessAcceleration()
        {
            if (throttle == null) return;

            rocket.Engine.Accelerate(throttle.value);
        }
    }
}