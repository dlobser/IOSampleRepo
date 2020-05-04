using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace Lobser
{

    public class Placeable : MonoBehaviour
    {
        public States.State state;
        private States.State prevState;

        public enum TransformState { MOVING, SCALING, ROTATING, NOTHING };
        public TransformState transformState;
        private TransformState prevTransformState;

        public GameObject artwork;
        public GameObject raycastTargets;
        public GameObject raycastMove;

        private PlaceableManager placeableManager;

        RaycastInteraction raycastInteraction;

        public bool initialPlacement;

        void Start()
        {
            placeableManager = FindObjectOfType<PlaceableManager>();
            placeableManager.AddPlaceable(this);

            raycastInteraction = FindObjectOfType<RaycastInteraction>();
        }

        void Update()
        {
            if (state == States.State.PLACING)
            {
                if (state != prevState)
                {
                    //raycastTargets.SetActive(true);
                    DisableArtColliders();
                    EnableRaycastColliders();
                    EnableRaycastRenderers();
                }

                if (Input.GetMouseButtonDown(0) && raycastInteraction.hitObject==raycastMove)
                {
                    placeableManager.DisableRaycastColliders();
                    transformState = TransformState.MOVING;
                }

                if (transformState == TransformState.MOVING && prevTransformState == transformState && !initialPlacement)
                {
                    if (raycastInteraction.hitObject.GetComponent<ARPlane>() != null  && Input.GetMouseButton(0))
                    {
                        transform.position = raycastInteraction.hitPosition;
                    }
                    else
                    {
                        transformState = TransformState.NOTHING;
                        placeableManager.EnableRaycastColliders();
                    }
                }

                if (transformState == TransformState.MOVING && initialPlacement)
                {
                    raycastInteraction.Raycast(false);
                    if (raycastInteraction.hitObject != null)
                    {

                        if (raycastInteraction.hitObject.GetComponent<ARPlane>()!=null)
                        {
                            placeableManager.DisableRaycastColliders();
                            transform.position = raycastInteraction.hitPosition;
                            Debug.Log(raycastInteraction.hitPosition);
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            raycastInteraction.useMouse = true;
                            transformState = TransformState.NOTHING;
                            placeableManager.EnableRaycastColliders();
                            initialPlacement = false;
                        }
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

            prevTransformState = transformState;
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