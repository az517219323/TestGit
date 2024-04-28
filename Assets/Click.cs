using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Camera UICamera;
    public Transform model;

    RaycastHit hitInfo;

    Vector3[] corners;
    // Start is called before the first frame update
    void Start()
    {
        corners = new Vector3[4];
        UICamera.CalculateFrustumCorners(UICamera.rect, UICamera.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);
        
    }

    // Update is called once per frame
    void Update()
    {
        UICamera.CalculateFrustumCorners(UICamera.rect, UICamera.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, corners);
        for (int i=0;i<corners.Length;i++)
        {
            var point = UICamera.ScreenToWorldPoint(corners[i]);
            Debug.DrawRay(UICamera.transform.position, point, Color.green);

        }
        if (Input.GetMouseButton(0))
        {
            var ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            var dir = ray1.direction;
            dir.z *= -1;
            dir.x *= -1;
            Ray ray = new Ray(UICamera.transform.position, dir);
            Debug.DrawRay(ray1.origin, ray1.direction, Color.green);
            Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
            var layer = 1 << LayerMask.NameToLayer("C");

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.LogError(hitInfo.collider.name);
                //if (hitInfo.collider.name == model.name)
                //{
                //    Debug.LogError(hitInfo.collider.name);
                //}
            }
            
        }
    }

    bool IsPointInRect(Vector2 point, RectTransform rectTrans)
    {
        Vector2 centerPoint = UICamera.WorldToScreenPoint(rectTrans.position);
        Rect rect = rectTrans.rect;

        bool isInRect = (point.x >= centerPoint.x - rect.size.x / 2) && (point.x <= centerPoint.x + rect.size.x / 2) && (point.y >= centerPoint.y - rect.size.y / 2) && (point.y <= centerPoint.y + rect.size.y / 2);
        return isInRect;
    }
}
