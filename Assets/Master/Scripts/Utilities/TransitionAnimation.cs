using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser { 
    public class TransitionAnimation : MonoBehaviour
    {
        public float speed;
        public bool transitioning;
        public virtual void Trigger() { }
        public virtual void Stop() { }
    }
}