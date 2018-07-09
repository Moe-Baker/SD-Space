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
	public static class References
	{
        public static void Set<T>(T reference) where T : Component
        {
            var list = reference.GetComponentsInChildren<Interface<T>>(true);

            for (int i = 0; i < list.Length; i++)
                list[i].Set(reference);
        }

		public interface Interface<T> where T : Component
        {
            void Set(T reference);
        }
	}
}