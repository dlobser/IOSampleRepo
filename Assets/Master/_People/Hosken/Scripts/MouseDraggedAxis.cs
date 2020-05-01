using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hosken
{

    /// <summary>
    /// When the mouse (or finger) is dragged, find the axis of greatest change. 
    /// Expose a public getter to get that axis at any time.
    /// </summary>
    public class MouseDraggedAxis : MonoBehaviour
    {

        public static MouseDraggedAxis current; // Set up Singleton for getting mouse dragged axis from anywhere

        private Vector2 mouseDraggedAxis;
        private Vector2 pMousePosition = Vector2.zero;

        private void Awake()
        {
            current = this; //There can only be one!
        }

        // Update is called once per frame
        void Update()
        {
            //Todo: Add buffer here to smooth out x and y locking?
            var delta = (Vector2)Input.mousePosition - pMousePosition;

            //only use axis of greatest change
            mouseDraggedAxis = Mathf.Abs( delta.x ) > Mathf.Abs( delta.y ) ? new Vector2(delta.x, 0) : new Vector2(0, delta.y);

            pMousePosition = Input.mousePosition;   //V3 to V2 conversion
        }

        public Vector2 GetMouseDraggedAxis()
        {
            return mouseDraggedAxis;
        }

    }

}