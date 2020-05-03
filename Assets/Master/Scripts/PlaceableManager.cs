using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser
{
    public class States
    {
        public enum State { NONE, PLACING, INTERACTING };
    }

    public class PlaceableManager : MonoBehaviour
    {
        public States.State state;
        private States.State prevState;

        public List<Placeable> placeables;
        public Placeable[] placeableLibrary;
        public int whichPlaceableToPlace;

        void Awake()
        {
            placeables = new List<Placeable>();
            state = States.State.PLACING;
        }

        private void Start()
        {

        }

        void Update()
        {
            if (prevState != state)
            {
                SwitchMode(state);
            }
            prevState = state;
        }

        public void SwitchState()
        {
            state = (state == States.State.INTERACTING) ? States.State.PLACING : States.State.INTERACTING;
        }

        public void AddPlaceable(Placeable newPlaceable)
        {
            placeables.Add(newPlaceable);
            newPlaceable.state = state;

            Debug.Log($"Added new Placeable object, state = {state}, count = {placeables.Count}");
        }

        public void CreatePlaceable(int which)
        {
            whichPlaceableToPlace = which;
            Placeable p = Instantiate(placeableLibrary[whichPlaceableToPlace]);
            placeables.Add(p);
            p.state = state;
            p.transformState = Placeable.TransformState.MOVING;
            p.initialPlacement = true;
            Debug.Log($"Added new Placeable object, state = {state}, count = {placeables.Count}");
        }

        private void SwitchMode(States.State state)
        {
            for (int i = 0; i < placeables.Count; i++)
            {
                placeables[i].state = state;
            }
        }

        public void EnableArtColliders()
        {
            foreach (Placeable placeable in placeables)
            {
                placeable.EnableArtColliders();
            }
        }

        public void DisableArtColliders()
        {
            foreach (Placeable placeable in placeables)
            {
                placeable.DisableArtColliders();
            }
        }

        public void EnableRaycastColliders()
        {
            foreach (Placeable placeable in placeables)
            {
                placeable.EnableRaycastColliders();
            }
        }

        public void DisableRaycastColliders()
        {
            foreach (Placeable placeable in placeables)
            {
                placeable.DisableRaycastColliders();
            }
        }

        void DeleteAll()
        {
            for (int i = 0; i < placeables.Count; i++)
            {
                Destroy(placeables[i].gameObject);
            }
            placeables = new List<Placeable>();

        }
    }
}