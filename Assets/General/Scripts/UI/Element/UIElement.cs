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
	public class UIElement : MonoBehaviour
	{
		public virtual bool Visibile
        {
            get
            {
                return gameObject.activeSelf;
            }
            set
            {
                if (value == Visibile) return;

                if (value)
                    Show();
                else
                    Hide();
            }
        }

        public event Action OnShow;
        public virtual void Show()
        {
            if (OnShow != null) OnShow();
        }

        public event Action OnHide;
        public virtual void Hide()
        {
            if (OnHide != null) OnHide();
        }
    }
}