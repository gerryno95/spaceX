using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IGA.UnityHelpers {
    public class ActionInvoker : MonoBehaviour
    {
        [SerializeField] string id = System.Guid.NewGuid().ToString();
        [SerializeField] UnityEvent onInvoke;


        public void Invoke()
        {
            if (onInvoke != null)
            {
                onInvoke.Invoke();
            }
        }

        public string GetID() { return id; }
    }
}
