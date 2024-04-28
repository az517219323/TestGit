using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRectPickImage : RawImage, IDragHandler, IPointerDownHandler
{
    public new Camera uicamera;
    private UIColorPicker picker;
    private Color pickColor = Color.red;
    private RawImage circleImage;

    protected override void Awake()
    {
        base.Awake();
        picker = transform.parent.GetComponent<UIColorPicker>();
        Rect rect = picker.CalculateInRect();
        rectTransform.sizeDelta = new Vector2(rect.width - 40, rect.height - 40);

        Transform tran = transform.Find("CircleImage");
        if (tran != null)
        {
            circleImage = tran.GetComponent<RawImage>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 screenPoint = eventData.pressPosition;
        PickColor(screenPoint);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 screenPoint = eventData.position;
        PickColor(screenPoint);
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        Texture tex = mainTexture;
        vh.Clear();
        if (tex != null)
        {
            var r = GetPixelAdjustedRect();
            var v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
            var scaleX = tex.width * tex.texelSize.x;
            var scaleY = tex.height * tex.texelSize.y;
            {
                var color32 = color;
                vh.AddVert(new Vector3(v.x, v.y), Color.black, new Vector2(uvRect.xMin * scaleX, uvRect.yMin * scaleY));
                vh.AddVert(new Vector3(v.x, v.w), Color.white, new Vector2(uvRect.xMin * scaleX, uvRect.yMax * scaleY));
                vh.AddVert(new Vector3(v.z, v.w), this.pickColor, new Vector2(uvRect.xMax * scaleX, uvRect.yMax * scaleY));
                vh.AddVert(new Vector3(v.z, v.y), Color.black, new Vector2(uvRect.xMax * scaleX, uvRect.yMin * scaleY));

                vh.AddTriangle(0, 1, 2);
                vh.AddTriangle(2, 3, 0);
            }
        }
    }

    // ɫ��ʰɫ�����
    public void SetPickColor(Color pickColor)
    {
        this.pickColor = pickColor;
        this.SetVerticesDirty();
    }

    // ��ȡʰɫ���ĵ�ǰ��ɫ
    public Color GetPickColor()
    {
        return ReadPickColor(circleImage.rectTransform.anchoredPosition);
    }

    // �ⲿ��ֵʱ����
    public void SetColor(Color color)
    {
        SetPickColor(color);
        Color c = color;
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        float min = Mathf.Min(Mathf.Min(c.r, c.g), c.b);
        //x��������ֵ
        float x = (1 - min / max) * rectTransform.sizeDelta.x - rectTransform.sizeDelta.x / 2;
        //y���ư���ֵ
        float y = max * rectTransform.sizeDelta.y - rectTransform.sizeDelta.y / 2;
        Vector2 localPoint = new Vector2(x, y);
        SetPickPosition(localPoint);
    }

    // ����СԲȦ�������������ɫ
    private Color ReadPickColor(Vector2 localPostion)
    {
        float w = rectTransform.sizeDelta.x;
        float h = rectTransform.sizeDelta.y;
        // ������ԭ���Ƶ����½�
        float x = localPostion.x + w / 2;
        float y = localPostion.y + h / 2;
        // �������һ��
        x = x / w;
        y = y / h;
        Color c = Color.Lerp(Color.white, this.pickColor, x);
        // ��ɫ�ᵽ����
        float max = Mathf.Max(Mathf.Max(c.r, c.g), c.b);
        c *= 1 / max;
        // ����y�����������ֵ
        c *= y;
        c.a = 1;
        return c;
    }

    // ͨ�����������������ȡɫ
    private void PickColor(Vector2 screenPoint)
    {
        Vector2 localPoint = ScreenPointToLocal(screenPoint);
        localPoint = AdjustPosition(localPoint);
        SetPickPosition(localPoint);
        Color c = ReadPickColor(localPoint);
        picker.SetPickColor(c);
    }

    // ��Ļ����ת��������
    private Vector2 ScreenPointToLocal(Vector2 screenPoint)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, uicamera, out localPoint);
        return localPoint;
    }

    // У�����꣬ȷ�������ھ�������
    private Vector2 AdjustPosition(Vector2 localPostion)
    {
        float R = rectTransform.sizeDelta.x / 2;
        localPostion.x = Mathf.Clamp(localPostion.x, -R, R);
        localPostion.y = Mathf.Clamp(localPostion.y, -R, R);
        return localPostion;
    }

    // ����СԲȦ����
    public void SetPickPosition(Vector2 localPostion)
    {
        if (circleImage == null)
            return;
        circleImage.rectTransform.anchoredPosition = localPostion;
    }
}
