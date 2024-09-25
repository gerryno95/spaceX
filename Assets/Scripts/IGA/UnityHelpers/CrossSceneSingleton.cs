using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IGA.UnityHelpers
{
    public abstract class CrossSceneSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected virtual void Awake()
        {

            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

        }
        public static T GetInstance()
        {
            if (Instance == null)
            {
                T find = FindObjectOfType<T>();
                if (find)
                {
                    Instance = find;
                }
                else
                {
                    GameObject newInstance = new GameObject("CrossSceneSingleton");
                    newInstance.AddComponent<T>();
                    Instance = newInstance.GetComponent<T>();
                }
                DontDestroyOnLoad(Instance.gameObject);
            }
            return Instance;
        }
    }
}
