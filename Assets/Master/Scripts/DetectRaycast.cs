using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lobser
{
    public class DetectRaycast : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
        IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public Vector3 hitPoint;
        public bool isHitting;
        public bool isDown;
        public bool debug;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(debug)
            Debug.Log("Drag Begin");
            isHitting = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
            isDown = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            isHitting = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
            if (debug)
                Debug.Log($"Dragging - GameObject: {gameObject.name}, Position: {hitPoint}");
            isDown = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Drag Ended");
            isHitting = false;
            isDown = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Clicked: " + eventData);
            isDown = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
            isHitting = true;
            isDown = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Mouse Enter");
            isHitting = true;
            isDown = false;

            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Mouse Exit");
            isHitting = false;
            isDown = false;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (debug)
                Debug.Log("Mouse Up");
            isHitting = false;
            isDown = false;
        }
    }

}
