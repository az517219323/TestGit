using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestDrag : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public Image DragMoveImg;

    private bool _isStartPress;

    private bool _isLongPress;

    private float pressTime;

    private float triggerTime = 0.5f;

    private Image _clickImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStartPress)
        {
            pressTime += Time.deltaTime;
            if (pressTime >= triggerTime)
            {
                Debug.LogError("长按已启动");
                _isStartPress = false;
                _isLongPress = true;
                pressTime = 0;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var clickGo = eventData.pointerCurrentRaycast.gameObject;
        _clickImage = clickGo?.GetComponentInParent<Image>();
        if (clickGo != null && _clickImage != null)
        {
            _isStartPress = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isStartPress = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isLongPress)
        {
            DragMoveImg.gameObject.SetActive(true);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isLongPress)
        {
            DragMoveImg.transform.position = _clickImage.transform.position;
            DragMoveImg.gameObject.SetActive(false);
            _isLongPress = false;
            pressTime = 0;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isLongPress)
        {
            var pos = Camera.main.ScreenToWorldPoint(eventData.position);
            var curWorldPos = pos;
            pos.z = _clickImage.transform.position.z;
            DragMoveImg.transform.position = pos;
        }
    }
}
