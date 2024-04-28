using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIColorPicker : UIBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler
{
    public new Camera uicamera;
    public RawImage circleImage;
    public RawImage pickImage;
    public GameObject rectPickImage;
    [SerializeField]
    private Color pickColor;

    //红绿蓝三基色所在角度
    private readonly float redAngle = 0;
    private readonly float greenAngle = 120;
    private readonly float blueAngle = 240;

    private bool canDrag = false;
    private UIRectPickImage m_RectPickImage;

    [Serializable]
    // 定义按钮OnChangeValue事件类
    public class OnChangeValueEvent : UnityEvent { }

    // 防止序列化变量重命名后丢失引用
    [FormerlySerializedAs("onChangeValue")]
    [SerializeField]
    private OnChangeValueEvent m_OnChangeValue = new OnChangeValueEvent();

    protected override void Awake()
    {
        base.Awake();
        m_RectPickImage = rectPickImage.AddComponent<UIRectPickImage>();
        m_RectPickImage.uicamera = uicamera;
        SetColor(pickColor);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 screenPoint = eventData.pressPosition;
        Vector2 localPoint = ScreenPointToLocal(eventData.pressPosition);
        // 鼠标是否击在色环上
        if (InCircleRound(localPoint))
            PickColor(screenPoint);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 鼠标必须要点在色环上才能拖动
        Vector2 localPoint = ScreenPointToLocal(eventData.pressPosition);
        canDrag = InCircleRound(localPoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
            return;
        Vector2 screenPoint = eventData.position;
        PickColor(screenPoint);
    }


    // 判断坐标是否在色环上
    private bool InCircleRound(Vector2 localPoint)
    {
        float length = localPoint.magnitude;
        float radius_out = circleImage.rectTransform.sizeDelta.x / 2; //外半径
        float radius_in = radius_out - pickImage.rectTransform.sizeDelta.x; //内半径
        return length >= radius_in && length <= radius_out;
    }

    // 纠正坐标，使小圆圈绕圆形轨迹运动
    private Vector2 AdjustPosition(Vector2 localPostion)
    {
        float R1 = circleImage.rectTransform.sizeDelta.x / 2;
        float R2 = pickImage.rectTransform.sizeDelta.x / 2;
        float length = R1 - R2;
        Vector2 normal = localPostion.normalized;
        localPostion = normal * length;
        return localPostion;
    }

    // 获取小圆圈所在角度
    public float GetAngle(Vector2 localPostion)
    {
        float angle = Vector2.Angle(Vector2.right, localPostion);
        if (localPostion.y < 0)
            angle = 360 - angle;
        return angle;
    }

    // 设置小圆圈坐标
    public void SetPickPosition(Vector2 localPostion)
    {
        pickImage.rectTransform.anchoredPosition = localPostion;
    }

    // 根据小圆圈所在坐标计算颜色
    private Color ReadPickColor(Vector2 localPostion)
    {
        Color c = Color.white;
        float t;
        float angle = GetAngle(localPostion);
        if (angle >= redAngle && angle <= greenAngle)
        {
            t = angle / 120;
            c = Color.Lerp(Color.red, Color.green, t);
        }
        else if (angle > greenAngle && angle <= blueAngle)
        {
            t = (angle - 120) / 120;
            c = Color.Lerp(Color.green, Color.blue, t);
        }
        else if (angle > blueAngle && angle <= 360)
        {
            t = (angle - 240) / 120;
            c = Color.Lerp(Color.blue, Color.red, t);
        }
        //颜色提到最亮
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        c *= 1 / max;
        return c;
    }

    // 通过鼠标所在屏蔽坐标取色
    private void PickColor(Vector2 screenPoint)
    {
        Vector2 localPoint = ScreenPointToLocal(screenPoint);
        localPoint = AdjustPosition(localPoint);
        SetPickPosition(localPoint);
        pickColor = ReadPickColor(localPoint);
        m_RectPickImage.SetPickColor(pickColor);
    }

    // 屏幕坐标转本地坐标
    private Vector2 ScreenPointToLocal(Vector2 screenPoint)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleImage.rectTransform, screenPoint, uicamera, out localPoint);
        return localPoint;
    }

    // 计算色环内矩形区大小
    public Rect CalculateInRect()
    {
        float radius_out = circleImage.rectTransform.sizeDelta.x / 2; //外半径
        float radius_in = radius_out - pickImage.rectTransform.sizeDelta.x; //内半径
        float half_width = Mathf.Sqrt(radius_in * radius_in / 2);//勾股定理计算内矩形半宽
        Rect rect = new Rect();
        rect.x = rect.y = 0;
        rect.width = rect.height = half_width * 2;
        return rect;
    }

    // 矩形拾色后回调
    public void SetPickColor(Color pickColor)
    {
        this.pickColor = pickColor;
    }

    // 获取拾色器的当前颜色
    public Color GetPickColor()
    {
        return m_RectPickImage.GetPickColor();
    }

    // 向拾取器设置颜色
    public void SetColor(Color color)
    {
        this.pickColor = color;
        Color c = color;

        // 找出最小分量
        float min = Mathf.Min(Mathf.Min(c.r, c.g), c.b);
        //颜色提到最亮
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        c *= 1 / max;

        float angle = 0;

        // 蓝色 (介于红-绿之间)
        if (Mathf.Approximately(color.b, min))
        {
            //0-60度之间 g=[0, 1]; 60-120度之间 r=[1, 0]
            if (c.r >= 1)
                angle = Mathf.Lerp(0, 60, c.g);
            else
                angle = Mathf.Lerp(60, 120, 1 - c.r);

        }
        // 绿色 (介于蓝-红之间)
        else if (Mathf.Approximately(color.g, min))
        {
            //240-300度之间 r=[0, 1]; 300-360度之间 b=[1, 0]
            if (c.b >= 1)
                angle = Mathf.Lerp(240, 300, c.r);
            else
                angle = Mathf.Lerp(300, 360, 1 - c.b);
        }
        // 红色 （介于绿-蓝之间）
        else if (Mathf.Approximately(color.r, min))
        {
            //120-180度之间 b=[0, 1]; 180-240度之间 g=[1, 0]
            if (c.g >= 1)
                angle = Mathf.Lerp(120, 180, c.b);
            else
                angle = Mathf.Lerp(180, 240, 1 - c.g);
        }

        float rad = angle * Mathf.Deg2Rad;
        float x = Mathf.Acos(rad);
        float y = Mathf.Asin(rad);

        Vector2 localPoint = new Vector2(x, y);
        localPoint = AdjustPosition(localPoint);
        SetPickPosition(localPoint);
        pickColor = ReadPickColor(localPoint);
        m_RectPickImage.SetColor(color);
    }
}
