using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser
{
    public class StateChange : MonoBehaviour
    {

        public GameObject[] activate;
        public GameObject[] deactivate;

        public TransitionAnimation[] transitions;
        TransitionAnimation[] allTransitions;

        public bool activateBeforeTransition;
        public bool deactivateBeforeTransition;

        bool swapActivateDeactivate = false;

        public bool trigger;


        public void Trigger(bool swap)
        {
            allTransitions = FindObjectsOfType<TransitionAnimation>();

            foreach (TransitionAnimation trans in allTransitions)
            {
                trans.Stop();
            }

            foreach (TransitionAnimation trans in transitions)
            {
                trans.Trigger();
            }

            if (activateBeforeTransition)
            {
                foreach (GameObject g in activate)
                    g.SetActive(!swapActivateDeactivate);
            }
            if (deactivateBeforeTransition)
            {
                foreach (GameObject g in deactivate)
                    g.SetActive(swapActivateDeactivate);
            }

            StartCoroutine(CheckTransitions());

            if (swap)
                swapActivateDeactivate = !swapActivateDeactivate;

        }

        IEnumerator CheckTransitions()
        {
            int transitionsDone = 0;
            while (transitionsDone < transitions.Length)
            {
                transitionsDone = 0;
                foreach (TransitionAnimation trans in transitions)
                {
                    if (!trans.transitioning)
                        transitionsDone++;
                }
                yield return null;
            }
            FinishTransition();
        }

        void FinishTransition()
        {

            if (!activateBeforeTransition)
            {
                foreach (GameObject g in activate)
                    g.SetActive(!swapActivateDeactivate);
            }
            if (!deactivateBeforeTransition)
            {
                foreach (GameObject g in deactivate)
                    g.SetActive(swapActivateDeactivate);
            }

        }

    }

}