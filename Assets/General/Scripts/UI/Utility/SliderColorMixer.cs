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
    [RequireComponent(typeof(Slider))]
	public class SliderColorMixer : MonoBehaviour
	{
        Slider slider;
        public float SlideRate
        {
            get
            {
                return (slider.value - slider.minValue) / (slider.maxValue - slider.minValue);
            }
        }
        
        [SerializeField]
        protected Color min = Color.yellow;
        public Color Min { get { return min; } }

        [SerializeField]
        protected Color max = Color.red;
        public Color Max { get { return max; } }

        [SerializeField]
        protected Image target;
        public Image Target { get { return target; } }

        protected virtual void Reset()
        {
            slider = GetComponent<Slider>();

            if (slider.fillRect != null)
                target = slider.fillRect.GetComponent<Image>();
        }

        protected virtual void Start()
        {
            slider = GetComponent<Slider>();

            slider.onValueChanged.AddListener(OnValueChanged);

            UpdateState();
        }

        protected virtual void UpdateState()
        {
            if(target != null)
                target.color = Color.Lerp(min, max, SlideRate);
        }

        protected virtual void OnValueChanged(float newValue)
        {
            UpdateState();
        }
	}
}