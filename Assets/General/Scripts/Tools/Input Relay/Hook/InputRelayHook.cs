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
    [RequireComponent(typeof(InputRelay))]
	public abstract class InputRelayHook : MonoBehaviour
	{
        protected virtual void Start()
        {
            var hook = GetComponent<InputRelay>();

            if (hook == null)
                throw new NullReferenceException(nameof(InputRelayHook) + " Requires a component of type " + nameof(InputRelay));

            hook.Event += Action;
        }

        protected virtual void Action()
        {
            
        }
    }
}