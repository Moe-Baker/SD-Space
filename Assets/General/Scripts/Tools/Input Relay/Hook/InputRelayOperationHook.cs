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
	public class InputRelayOperationHook : InputRelayHook
	{
        [SerializeField]
        protected bool includeChildern = true;
        public bool IncludeChildern { get { return includeChildern; } }

        protected override void Action()
        {
            base.Action();

            Operation.ExecuteAll(gameObject, includeChildern);
        }
    }
}