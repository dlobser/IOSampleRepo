using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lobser
{
    public class PlaceableManager : MonoBehaviour
    {
        public enum State { PLACING, INTERACTING };
        public State state;

        public List<Placeable> placeables;

        void Awake()
        {
            placeables = new List<Placeable>();
        }

        void Update()
        {

        }

        public void EnableAllColliders()
        {
            for (int i = 0; i < placeables.Count; i++)
            {
                Collider[] colliders = placeables[i].GetComponentsInChildren<Collider>();
                foreach(Collider c in colliders)
                {
                    c.enabled = true;
                }
            }
        }

        public void DisableAllColliders()
        {
            for (int i = 0; i < placeables.Count; i++)
            {
                Collider[] colliders = placeables[i].GetComponentsInChildren<Collider>();
                foreach (Collider c in colliders)
                {
                    c.enabled = false;
                }
            }
        }

        void SwitchMode()
        {
            for (int i = 0; i < placeables.Count; i++)
            {
            }
        }

        void TriggerAll()
        {
            for (int i = 0; i < placeables.Count; i++)
            {
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