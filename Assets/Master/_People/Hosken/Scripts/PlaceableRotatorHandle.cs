using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Hosken
{

    //Unfortunately this system requires that the placeable model has no colliders,
    // as I am unsure how to restrict the IPointer system to certain layers

    /// <summary>
    /// The purpose of this class is to simply tell the Placeable object that 
    /// it should rotate. PlaceableRotator handles all the rotation stuff
    /// </summary>
    public class PlaceableRotatorHandle : MonoBehaviour, IDragHandler
    {

        PlaceableRotator rotator;

        private void Start()
        {
            rotator = GetComponentInParent<PlaceableRotator>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            print("Handle Dragged");
            rotator.OnDragged();
        }

    }

}