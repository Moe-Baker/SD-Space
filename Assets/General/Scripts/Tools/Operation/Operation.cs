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
	public static class Operation
	{
        public static void ExeuteAll(GameObject gameObject)
        {
            ExecuteAll(gameObject, false);
        }
        public static void ExecuteAll(GameObject gameObject, bool includeChildern)
        {
            Interface[] operations;

            if (includeChildern)
                operations = gameObject.GetComponentsInChildren<Interface>();
            else
                operations = gameObject.GetComponents<Interface>();

            for (int i = 0; i < operations.Length; i++)
                operations[i].Execute();
        }

        public interface Interface
        {
            void Execute();
        }
	}
}