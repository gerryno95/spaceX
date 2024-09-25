using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IGA.UnityHelpers
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; protected set; }
        protected virtual void Awake()
        {
            Instance = this as T;
        }
        public static T GetInstance()
        {
            return Instance;
        }
    }
}
