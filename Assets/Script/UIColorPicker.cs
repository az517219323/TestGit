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

    //����������ɫ���ڽǶ�
    private readonly float redAngle = 0;
    private readonly float greenAngle = 120;
    private readonly float blueAngle = 240;

    private bool canDrag = false;
    private UIRectPickImage m_RectPickImage;

    [Serializable]
    // ���尴ťOnChangeValue�¼���
    public class OnChangeValueEvent : UnityEvent { }

    // ��ֹ���л�������������ʧ����
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
        // ����Ƿ����ɫ����
        if (InCircleRound(localPoint))
            PickColor(screenPoint);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ������Ҫ����ɫ���ϲ����϶�
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


    // �ж������Ƿ���ɫ����
    private bool InCircleRound(Vector2 localPoint)
    {
        float length = localPoint.magnitude;
        float radius_out = circleImage.rectTransform.sizeDelta.x / 2; //��뾶
        float radius_in = radius_out - pickImage.rectTransform.sizeDelta.x; //�ڰ뾶
        return length >= radius_in && length <= radius_out;
    }

    // �������꣬ʹСԲȦ��Բ�ι켣�˶�
    private Vector2 AdjustPosition(Vector2 localPostion)
    {
        float R1 = circleImage.rectTransform.sizeDelta.x / 2;
        float R2 = pickImage.rectTransform.sizeDelta.x / 2;
        float length = R1 - R2;
        Vector2 normal = localPostion.normalized;
        localPostion = normal * length;
        return localPostion;
    }

    // ��ȡСԲȦ���ڽǶ�
    public float GetAngle(Vector2 localPostion)
    {
        float angle = Vector2.Angle(Vector2.right, localPostion);
        if (localPostion.y < 0)
            angle = 360 - angle;
        return angle;
    }

    // ����СԲȦ����
    public void SetPickPosition(Vector2 localPostion)
    {
        pickImage.rectTransform.anchoredPosition = localPostion;
    }

    // ����СԲȦ�������������ɫ
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
        //��ɫ�ᵽ����
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        c *= 1 / max;
        return c;
    }

    // ͨ�����������������ȡɫ
    private void PickColor(Vector2 screenPoint)
    {
        Vector2 localPoint = ScreenPointToLocal(screenPoint);
        localPoint = AdjustPosition(localPoint);
        SetPickPosition(localPoint);
        pickColor = ReadPickColor(localPoint);
        m_RectPickImage.SetPickColor(pickColor);
    }

    // ��Ļ����ת��������
    private Vector2 ScreenPointToLocal(Vector2 screenPoint)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleImage.rectTransform, screenPoint, uicamera, out localPoint);
        return localPoint;
    }

    // ����ɫ���ھ�������С
    public Rect CalculateInRect()
    {
        float radius_out = circleImage.rectTransform.sizeDelta.x / 2; //��뾶
        float radius_in = radius_out - pickImage.rectTransform.sizeDelta.x; //�ڰ뾶
        float half_width = Mathf.Sqrt(radius_in * radius_in / 2);//���ɶ�������ھ��ΰ��
        Rect rect = new Rect();
        rect.x = rect.y = 0;
        rect.width = rect.height = half_width * 2;
        return rect;
    }

    // ����ʰɫ��ص�
    public void SetPickColor(Color pickColor)
    {
        this.pickColor = pickColor;
    }

    // ��ȡʰɫ���ĵ�ǰ��ɫ
    public Color GetPickColor()
    {
        return m_RectPickImage.GetPickColor();
    }

    // ��ʰȡ��������ɫ
    public void SetColor(Color color)
    {
        this.pickColor = color;
        Color c = color;

        // �ҳ���С����
        float min = Mathf.Min(Mathf.Min(c.r, c.g), c.b);
        //��ɫ�ᵽ����
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        c *= 1 / max;

        float angle = 0;

        // ��ɫ (���ں�-��֮��)
        if (Mathf.Approximately(color.b, min))
        {
            //0-60��֮�� g=[0, 1]; 60-120��֮�� r=[1, 0]
            if (c.r >= 1)
                angle = Mathf.Lerp(0, 60, c.g);
            else
                angle = Mathf.Lerp(60, 120, 1 - c.r);

        }
        // ��ɫ (������-��֮��)
        else if (Mathf.Approximately(color.g, min))
        {
            //240-300��֮�� r=[0, 1]; 300-360��֮�� b=[1, 0]
            if (c.b >= 1)
                angle = Mathf.Lerp(240, 300, c.r);
            else
                angle = Mathf.Lerp(300, 360, 1 - c.b);
        }
        // ��ɫ ��������-��֮�䣩
        else if (Mathf.Approximately(color.r, min))
        {
            //120-180��֮�� b=[0, 1]; 180-240��֮�� g=[1, 0]
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
