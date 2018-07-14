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
	public class FollowCamera : MonoBehaviour
	{
		[SerializeField]
        protected Transform target;
        public Transform Target { get { return target; } }
        public virtual Vector3 FollowPosition { get { return target.position + offset; } }

        [SerializeField]
        protected Vector3 offset = new Vector3(0f, 8f, -15f);
        public Vector3 Offset { get { return offset; } }

        protected virtual void LateUpdate()
        {
            ProcessFollow();
        }

        protected virtual void ProcessFollow()
        {
            transform.position = FollowPosition;
        }
    }
}