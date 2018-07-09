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
	public class TransitionUIElementOperation : MonoBehaviour, Operation.Interface
	{
        [SerializeField]
        protected UIElement current;
        public UIElement Current { get { return current; } }

        [SerializeField]
        protected UIElement target;
        public UIElement Target { get { return target; } }

        protected virtual void Reset()
        {
            current = Dependency.Find<UIElement>(gameObject, Dependency.Direction.Up);
        }

        public virtual void Execute()
        {
            if (current == null)
                Debug.LogWarning("No current element set for " + nameof(TransitionUIElementOperation));
            else
                current.Hide();

            if (target == null)
                Debug.LogWarning("No target element set for " + nameof(TransitionUIElementOperation));
            else
                target.Show();
        }
	}
}