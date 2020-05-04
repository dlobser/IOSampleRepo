using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hosken
{
    /// <summary>
    /// Rotate a child pivot according to an X and Y axis (in our implementation a mouse/finger drag).
    /// X axis will rotate pivot around World Space Y, 
    /// and Y axis will rotate pivot around Camera Space X (the viewer's pitch axis)
    /// </summary>
    public class PlaceableRotator : MonoBehaviour
    {

        [Tooltip("Use to lock rotation to Y axis only. Helful for models with a definite 'Up'")]
        [SerializeField] bool rotateYOnly = false;

        Transform pivot;
        Transform camTransform;

        public float speed = 1;

        void Start()
        {
            pivot = this.transform;// transform.Find("Pivot");        // Find pivot object in children. Use Pivot as container for whatever models are added.
            camTransform = Camera.main.transform;   // Use camera X axis to rotate 'up and down'

        }

        public void OnDragged()
        {
            Vector2 axis = MouseDraggedAxis.current.GetMouseDraggedAxis();  

            pivot.Rotate(-1 * Vector3.up * axis.x * speed, Space.World);
            
            if (!rotateYOnly) pivot.Rotate(camTransform.right * axis.y * speed, Space.World);
            
        }

        
    }
}