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
	public class ShowUIElementOperation : MonoBehaviour, Operation.Interface
	{
        [SerializeField]
        protected UIElement target;
        public UIElement Target { get { return target; } }

        public virtual void Execute()
        {
            if (target == null)
                throw new NullReferenceException("No target specificed for " + nameof(ShowUIElementOperation));

            target.Show();
        }
    }
}