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
	public class RocketFuel : MonoBehaviour
	{
        [SerializeField]
        protected float value;
        public float Value
        {
            get
            {
                return value;
            }
            set
            {
                value = Mathf.Clamp(value, 0f, max);

                this.value = value;

                if (OnValueChange != null) OnValueChange(this.value);
                TriggerStateChange();
            }
        }
        public event ValueChangeDelegate OnValueChange;

        [SerializeField]
        protected float max;
        public float Max
        {
            get
            {
                return max;
            }
            set
            {
                if (value < 0f)
                    value = 0f;

                max = value;

                if (OnMaxChange != null) OnMaxChange(max);
                TriggerStateChange();
            }
        }
        public event ValueChangeDelegate OnMaxChange;

        public float Rate { get { return value / max; } }

        public delegate void ValueChangeDelegate(float newValue);

        public event Action OnStateChange;
        protected virtual void TriggerStateChange()
        {
            if (OnStateChange != null) OnStateChange();
        }

        protected virtual void Reset()
        {
            value = max = 100f;
        }
    }
}