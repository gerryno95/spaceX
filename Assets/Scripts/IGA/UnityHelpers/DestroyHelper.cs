using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IGA.UnityHelpers {
    public class DestroyHelper : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
        public void Destroy(float waitTime)
        {
            Destroy(gameObject, waitTime);
        }
    }
}
