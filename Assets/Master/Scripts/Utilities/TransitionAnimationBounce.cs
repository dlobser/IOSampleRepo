using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser
{
    public class TransitionAnimationBounce : TransitionAnimation
    {
        public override void Trigger() {
            StartCoroutine(Bounce());
        }

        IEnumerator Bounce()
        {
            transitioning = true;
            float counter = 0;
            while (counter < 1)
            {
                counter += Time.deltaTime / speed;
                this.transform.localPosition = new Vector3(0, Mathf.Cos(counter * Mathf.PI * 2), 0);
                yield return null;
            }
            transitioning = false;
        }

        public override void Stop() { }
    }
}