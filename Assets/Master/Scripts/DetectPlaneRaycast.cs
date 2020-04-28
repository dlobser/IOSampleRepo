using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lobser { 
    public class DetectPlaneRaycast : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
        IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public Vector3 hitPoint;
        public bool isHitting;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Begin");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Dragging");
            isHitting = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Ended");
            isHitting = false;

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + eventData);//eventData.pointerCurrentRaycast.gameObject.name);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
            isHitting = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Mouse Enter");
            isHitting = true;
            hitPoint = eventData.pointerCurrentRaycast.worldPosition;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Mouse Exit");
            isHitting = false;

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Mouse Up");
            isHitting = false;

        }
    }

}
