//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Lobser {
//    public class Placeable : MonoBehaviour
//    {

//        public enum State { PLACING, INTERACTING };
//        public State state;
//        State prevState;

//        public enum TransformState { MOVING, SCALING, ROTATING, NOTHING };
//        public TransformState transformState;

//        public GameObject artwork;
//        public GameObject raycastTargets;

//        public GameObject raycastMove;

//        void Start()
//        {
//            transformState = TransformState.NOTHING;
//            FindObjectOfType<PlaceableManager>().placeables.Add(this);
//            Debug.Log(FindObjectOfType<PlaceableManager>().placeables);
//        }

//        void Update()
//        {
//            if (state == State.PLACING)
//            {
//                if (state != prevState)
//                {
//                    raycastTargets.SetActive(true);
//                    EnableDisableColliders(false);
//                }

//                if (raycastMove.GetComponent<DetectPlaneRaycast>().isHitting)
//                {
//                    //raycastMove.GetComponent<Collider>().enabled = false;
//                    FindObjectOfType<PlaceableManager>().DisableAllColliders();
//                    transformState = TransformState.MOVING;
//                }

//                if(transformState == TransformState.MOVING)
//                {
//                    if (GameObject.Find("Plane").GetComponent<DetectPlaneRaycast>().isHitting)
//                    {
//                        this.transform.position = GameObject.Find("Plane").GetComponent<DetectPlaneRaycast>().hitPoint;
//                    }
//                }



//            }

//            if (state == State.INTERACTING)
//            {
//                if (state != prevState)
//                {
//                    raycastTargets.SetActive(false);
//                    EnableDisableColliders(true);
//                }
//            }

//            prevState = state;
//        }

//        void EnableDisableColliders(bool active)
//        {
//            Collider[] colliders = artwork.GetComponentsInChildren<Collider>();
//            foreach (Collider c in colliders)
//            {
//                c.enabled = active;
//            }
//        }


//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser
{

    public class Placeable : MonoBehaviour
    {
        public States.State state;
        private States.State prevState;

        public enum TransformState { MOVING, SCALING, ROTATING, NOTHING };
        public TransformState transformState;

        public GameObject artwork;
        public GameObject raycastTargets;
        public GameObject raycastMove;

        private PlaceableManager placeableManager;
        private GameObject plane;
        private DetectRaycast planeRaycastDetection;
        private DetectRaycast raycastMoveDetection;

        void Start()
        {
            transformState = TransformState.NOTHING;

            placeableManager = FindObjectOfType<PlaceableManager>();
            placeableManager.AddPlaceable(this);

            plane = GameObject.Find("Plane");
            planeRaycastDetection = plane.GetComponent<DetectRaycast>();
            raycastMoveDetection = raycastMove.GetComponent<DetectRaycast>();
        }

        void Update()
        {
            if (state == States.State.PLACING)
            {
                if (state != prevState)
                {
                    raycastTargets.SetActive(true);
                    DisableArtColliders();
                    EnableRaycastColliders();
                    EnableRaycastRenderers();
                }

                if (raycastMoveDetection.isHitting)
                {
                    placeableManager.DisableRaycastColliders();
                    transformState = TransformState.MOVING;
                    Debug.Log("is down");
                    //raycastMove.SetActive(false);
                }
                Debug.Log(transformState);

                if (transformState == TransformState.MOVING)
                {
                    if (planeRaycastDetection.isHitting && Input.GetMouseButton(0))
                    {
                        //print("Raycast hitting the plane: " + planeRaycastDetection.hitPoint);
                        transform.position = raycastMoveDetection.hitPoint;
                    }
                    else
                    {
                        transformState = TransformState.NOTHING;
                        placeableManager.EnableRaycastColliders();
                    }
                }
            }

            if (state == States.State.INTERACTING)
            {
                if (state != prevState)
                {
                    DisableRaycastColliders();
                    EnableArtColliders();
                    DisableRaycastRenderers();
                }
            }

            prevState = state;
        }

        public void EnableArtColliders()
        {
            EnableDisableColliders(artwork, true);
        }

        public void DisableArtColliders()
        {
            EnableDisableColliders(artwork, false);
        }

        public void EnableRaycastColliders()
        {
            EnableDisableColliders(raycastTargets, true);
        }

        public void DisableRaycastColliders()
        {
            EnableDisableColliders(raycastTargets, false);

        }
        public void EnableRaycastRenderers()
        {
            EnableDisableRenderers(raycastTargets, true);
        }

        public void DisableRaycastRenderers()
        {
            EnableDisableRenderers(raycastTargets, false);

        }

        private void EnableDisableColliders(GameObject targetGameObject, bool isEnabled)
        {
            Collider[] colliders = targetGameObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                c.enabled = isEnabled;
            }
        }

        private void EnableDisableRenderers(GameObject targetGameObject, bool isEnabled)
        {
            Renderer[] renderers = targetGameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.enabled = isEnabled;
            }
        }
    }
}