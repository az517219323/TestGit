using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RockerControlUI : MonoBehaviour,IDragHandler,IEndDragHandler
{
    private RectTransform parentTrans;
    private Vector2 startPos = Vector2.zero;
    private Vector2 moveDir = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        parentTrans = transform.parent.transform as RectTransform;
        startPos = parentTrans.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 tranVec = eventData.position - startPos;

        float radius = Vector2.Distance(eventData.position, startPos);
        radius = Mathf.Clamp(radius, 0, parentTrans.rect.width / 2);

        moveDir = tranVec.normalized * radius;
        transform.position = startPos + moveDir;

        Debug.LogError(transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
        moveDir = Vector2.zero;
    }

    public Vector2 GetMoveDir()
    {
        return moveDir;
    }
}
