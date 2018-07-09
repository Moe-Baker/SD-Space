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
    public class RocketEngine : MonoBehaviour, Rocket.IReference
    {
        public Rocket Rocket { get; protected set; }
        void References.Interface<Rocket>.Set(Rocket reference)
        {
            Rocket = reference;
        }

        new public Rigidbody rigidbody { get { return Rocket.rigidbody; } }
    }
}