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

using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game
{
	public class ImageHoldEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
        [SerializeField]
        protected UnityEvent _event;
        public UnityEvent Event { get { return _event; } }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            coroutine = StartCoroutine(Procedure());
        }

        Coroutine coroutine;
        protected virtual IEnumerator Procedure()
        {
            while (true)
            {
                _event.Invoke();

                yield return new WaitForEndOfFrame();
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}