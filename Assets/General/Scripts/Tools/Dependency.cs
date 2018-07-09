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
	public static class Dependency
	{
		public static T Find<T>(GameObject gameObject)
        {
            return Find<T>(gameObject, Direction.Down);
        }

        public static T Find<T>(GameObject gameObject, Direction direction)
        {
            return Find<T>(gameObject, direction, int.MaxValue);
        }

        public static T Find<T>(GameObject gameObject, Direction direction, int depth)
        {
            var resault = gameObject.GetComponent<T>();

            if (resault == null && depth > 1)
            {
                var directionalObjects = FindObjectsInDirection(gameObject, direction);

                for (int i = 0; i < directionalObjects.Length; i++)
                {
                    resault = Find<T>(directionalObjects[i], direction, depth - 1);

                    if (resault != null) break;
                }
            }

            return resault;
        }

        public static GameObject[] FindObjectsInDirection(GameObject origin, Direction direction)
        {
            if (direction == Direction.Up)
            {
                if (origin.transform.parent == null)
                    return new GameObject[] { };
                else
                    return new GameObject[] { origin.transform.parent.gameObject };
            }
            else
            {
                var resault = new GameObject[origin.transform.childCount];

                for (int i = 0; i < resault.Length; i++)
                    resault[i] = origin.transform.GetChild(i).gameObject;

                return resault;
            }
        }

        public enum Direction { Up, Down };
	}
}