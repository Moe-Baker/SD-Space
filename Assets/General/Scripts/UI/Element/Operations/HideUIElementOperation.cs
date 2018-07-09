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
	public class HideUIElementOperation : MonoBehaviour, Operation.Interface
	{
        [SerializeField]
        protected UIElement target;
        public UIElement Target { get { return target; } }

        protected virtual void Reset()
        {
            target = Dependency.Find<UIElement>(gameObject, Dependency.Direction.Up);
        }

        public virtual void Execute()
        {
            if (target == null)
                throw new NullReferenceException("No target specificed for " + nameof(HideUIElementOperation));

            target.Hide();
        }
    }
}