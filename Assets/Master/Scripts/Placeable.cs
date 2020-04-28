using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser {
    public class Placeable : MonoBehaviour
    {

        public enum State { PLACING, INTERACTING };
        public State state;
        State prevState;

        public enum TransformState { MOVING, SCALING, ROTATING, NOTHING };
        public TransformState transformState;

        public GameObject artwork;
        public GameObject raycastTargets;

        public GameObject raycastMove;

        void Start()
        {
            transformState = TransformState.NOTHING;
            FindObjectOfType<PlaceableManager>().placeables.Add(this);
            Debug.Log(FindObjectOfType<PlaceableManager>().placeables);
        }

        void Update()
        {
            if (state == State.PLACING)
            {
                if (state != prevState)
                {
                    raycastTargets.SetActive(true);
                    EnableDisableColliders(false);
                }

                if (raycastMove.GetComponent<DetectPlaneRaycast>().isHitting)
                {
                    //raycastMove.GetComponent<Collider>().enabled = false;
                    FindObjectOfType<PlaceableManager>().DisableAllColliders();
                    transformState = TransformState.MOVING;
                }

                if(transformState == TransformState.MOVING)
                {
                    if (GameObject.Find("Plane").GetComponent<DetectPlaneRaycast>().isHitting)
                    {
                        this.transform.position = GameObject.Find("Plane").GetComponent<DetectPlaneRaycast>().hitPoint;
                    }
                }



            }

            if (state == State.INTERACTING)
            {
                if (state != prevState)
                {
                    raycastTargets.SetActive(false);
                    EnableDisableColliders(true);
                }
            }

            prevState = state;
        }

        void EnableDisableColliders(bool active)
        {
            Collider[] colliders = artwork.GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                c.enabled = active;
            }
        }


    }
}