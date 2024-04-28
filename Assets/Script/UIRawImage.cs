using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRawImage : RawImage, IPointerClickHandler
{
    private Camera _renderCamera;
    private Camera _uiCamera;
    private Vector2 _clickPos;

    protected override void Start()
    {
        _uiCamera = Camera.main;
        _renderCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        CheckDrawRayLine(false);
        //GetRawImageObj(data, rectTransform, _renderCamera);
#endif
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponentInParent<Canvas>().transform as RectTransform, eventData.position, eventData.pressEventCamera, out _clickPos))
        {
            CheckDrawRayLine(true);
        }
    }



    void CheckDrawRayLine(bool isCallBack)
    {
        if (_renderCamera != null && _clickPos != null)
        {
            //获取预览图的长宽
            float imageWidth = rectTransform.rect.width;
            float imageHeight = rectTransform.rect.height;

            var localPosition = GetLocalPositionByPivot(Vector2.zero);
            //获取预览图的坐标，此处RawImage的Pivot需为(0,0)，不然自己再换算下
            float localPositionX = localPosition.x;
            float localPositionY = localPosition.y;

            //获取在预览映射相机viewport内的坐标（坐标比例）
            float p_x = (_clickPos.x - localPositionX) / imageWidth;
            float p_y = (_clickPos.y - localPositionY) / imageHeight;

            //从视口坐标发射线
            Ray p_ray = _renderCamera.ViewportPointToRay(new Vector2(p_x, p_y));
            RaycastHit p_hitInfo;
            if (Physics.Raycast(p_ray, out p_hitInfo))
            {
                //显示射线，只有在scene视图中才能看到
                Debug.DrawLine(p_ray.origin, p_hitInfo.point);
                Debug.Log(p_hitInfo.transform.name);
            }
        }
    }

    private Vector2 GetLocalPositionByPivot(Vector2 povit)
    {
        RectTransform parentRect = transform.parent.GetComponent<RectTransform>();
        // 通过OffsetMin、OffsetMax，将anchoredPosition和localPosition联系起来
        Vector2 localPosition2D = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y);
        Vector2 anchorMinPos = parentRect.rect.min + Vector2.Scale(rectTransform.anchorMin, parentRect.rect.size);
        Vector2 rectMinPos = rectTransform.rect.min + localPosition2D;
        Vector2 offsetMin = rectMinPos - anchorMinPos;

        Vector2 anchorMaxPos = parentRect.rect.max - Vector2.Scale(Vector2.one - rectTransform.anchorMax, parentRect.rect.size);
        Vector2 rectMaxPos = rectTransform.rect.max + localPosition2D;
        Vector2 offsetMax = rectMaxPos - anchorMaxPos;

        Vector2 sizeDelta = offsetMax - offsetMin;

        Vector2 anchoredPosition = offsetMin + Vector2.Scale(sizeDelta, povit);
        return anchoredPosition;
    }
}
