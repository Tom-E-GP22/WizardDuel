using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [Header("Components")]
    public Image spellQueue;
    private SpellQueue spellQueueCS;
    private Transform originalParent;
    private ElementContainer parentScript;
    private RectTransform rectTransform;
    private Canvas canvas;

    [Header("Positions & Sizes")]
    private Rect spellQueueRect;
    private Vector2[] spellSlots = new Vector2[5];
    private Rect elementRect;
    private Vector2 regularSize = new Vector2(300f, 300f);
    private Vector2 selectedSize = new Vector2(200f, 200f);
    private Vector2 pos;
    private int startIndex;

    private void Start()
    {
        spellQueueCS = spellQueue.GetComponent<SpellQueue>();
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        startIndex = transform.parent.GetSiblingIndex();
        originalParent = transform.parent;
        parentScript = originalParent.GetComponent<ElementContainer>();

        Vector2 sizeDelta = rectTransform.sizeDelta;
        elementRect.width = sizeDelta.x * rectTransform.lossyScale.x;
        elementRect.height = sizeDelta.y * rectTransform.lossyScale.y;

        sizeDelta = spellQueue.rectTransform.sizeDelta;
        spellQueueRect.width = sizeDelta.x * spellQueue.rectTransform.lossyScale.x;
        spellQueueRect.height = sizeDelta.y * spellQueue.rectTransform.lossyScale.y;
        spellQueueRect.position = spellQueue.transform.TransformPoint(spellQueue.rectTransform.position);

        int x = -400;
        for(int i = 0; i < 5; i++)
        {
            spellSlots[i].y = 15;
            spellSlots[i].x = x;

            x += 200;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin Drag");
        transform.parent = originalParent;
        rectTransform.sizeDelta = regularSize;
        transform.parent.SetSiblingIndex(4);
        transform.SetSiblingIndex(1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        rectTransform.position = canvas.transform.TransformPoint(pos);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (CheckOverlap())
        {
            transform.parent = spellQueue.transform;
            rectTransform.sizeDelta = selectedSize;
            rectTransform.position = canvas.transform.TransformPoint(ClosestPoint());
        }
        else
        {
            sendBack();
        }
        Debug.Log("on drop");
        parentScript.UpdateElement();
    }

    private bool CheckOverlap()
    {
        elementRect.position = transform.TransformPoint(rectTransform.position);

        if (elementRect.Overlaps(spellQueueRect, true))
            return true;
        else
            return false;
    }

    private Vector2 ClosestPoint()
    {
        float closestPointDistance = 50;
        Vector2 closestPoint = new Vector2();
        pos = canvas.transform.TransformPoint(pos);
        int slot = 0;

        for (int i = 0; i < 5; i++)
        {
            Vector2 slotWorldPoint = canvas.transform.TransformPoint(spellSlots[i]);
            Debug.Log(slotWorldPoint);
            if (closestPointDistance > Vector2.SqrMagnitude(slotWorldPoint - pos))
            {
                closestPointDistance = Vector2.SqrMagnitude(slotWorldPoint - pos);
                closestPoint = spellSlots[i];
                slot = i;
            }
        }
        spellQueueCS.addToQueue(slot);
            return closestPoint;
    }

    private void sendBack()
    {
        //Check if slot empty
        rectTransform.localPosition = Vector2.zero;
        transform.parent.SetSiblingIndex(startIndex);
        transform.SetSiblingIndex(0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("on end drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("on pointer down");
    }
}
