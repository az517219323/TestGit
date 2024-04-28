using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace pff.Homestead
{
    public class Drag : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
    {
        public Slider _slider;

        private bool _judge;
        private Vector2 _anchor;//偏移的圆心
        private Vector2 _lastPoint;  //上一帧坐标
        private Vector2 _dir;
        private float _lastAngle;

        private bool m_IsFirst = true;//用于记录第一帧按下鼠标时鼠标的位置，便于计算
        private Vector3 m_CurrentPos;//记录当前帧鼠标所在位置
        private bool m_IsClockwise;//是否顺时针
        private float m_RoundValue = 0;//记录总的旋转角度 用这个数值来控制一圈半
        public float Speed = 58.8f;//动画播放速度
        //public GameObject Lingjian;//手轮零件
        //public GameObject NiutouAnimator;//动画
        // Start is called before the first frame update
        void Start()
        {
            
        }

        void Update()
        {
            //if (Input.GetMouseButtonUp(0))
            //{
            //    _judge = false;
            //}

            //if (Input.GetMouseButtonDown(0))
            //{
            //    _lastPoint = Input.mousePosition;
            //    _anchor = _lastPoint - new Vector2(0, 50);//鼠标点击 在点击位置下方设置偏移一定数值的圆心（具体偏移量看实际运用
            //    _dir = (_lastPoint - _anchor).normalized;
            //    _judge = true;
            //}

            //if (_judge)
            //{
            //    Vector2 currentPoint = Input.mousePosition;
            //    var currentDragDir = (currentPoint - _anchor).normalized;
            //    var deltaAngle = Vector2.Angle(_dir, currentDragDir);
            //    _lastAngle += deltaAngle;
            //    Debug.Log(deltaAngle);
            //    Debug.LogError(_lastAngle % 360);
            //    _dir = currentDragDir;
            //    //Debug.Log(TouchJudge(Input.mousePosition, ref _lastPoint, _anchor));
            //}
        }


        /// <summary>
        /// 判断顺时针逆时针
        /// (顺正逆负
        /// </summary>
        /// <param name="current">当前坐标</param>
        /// <param name="last">上个坐标(ref 更新</param>
        /// <param name="anchor">锚点</param>
        /// <returns></returns>
        private float TouchJudge(Vector2 current, ref Vector2 last, Vector2 anchor)
        {
            Vector2 lastDir = (last - anchor).normalized;//上次方向
            Vector2 currentDir = (current - anchor).normalized;//当前方向

            float lastDot = Vector2.Dot(Vector2.up, lastDir);
            float currentDot = Vector2.Dot(Vector2.up, currentDir);

            float lastAngle = last.x < anchor.x //用y点判断上下扇面

                ? Mathf.Acos(lastDot) * Mathf.Rad2Deg
                : -Mathf.Acos(lastDot) * Mathf.Rad2Deg;

            float currentAngle = current.x < anchor.x
                ? Mathf.Acos(currentDot) * Mathf.Rad2Deg
                : -Mathf.Acos(currentDot) * Mathf.Rad2Deg;

            Debug.LogError(currentAngle);
            last = current;
            return currentAngle - lastAngle;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_judge)
            {
                Vector2 currentPoint = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y,
                Camera.main.transform.position.z > 0 ? Camera.main.transform.position.z : -Camera.main.transform.position.z));
                var currentDragDir = (currentPoint - _anchor).normalized;
                var deltaAngle = Vector2.Angle(_dir, currentDragDir);
                float rotationDir = _dir.x * currentDragDir.y - _dir.y * currentDragDir.x;
                if (rotationDir > 0)
                {
                    _lastAngle -= deltaAngle;
                    _lastAngle = Mathf.Clamp(_lastAngle, 0, 360);
                }
                else if (rotationDir < 0)
                {
                    _lastAngle += deltaAngle;
                }
                if (_lastAngle >= 360)
                {
                    _lastAngle = _lastAngle % 360;
                }
                _slider.value = _lastAngle / 360;
                Debug.Log(deltaAngle);
                Debug.LogError(_lastAngle % 360);
                _dir = currentDragDir;
                //RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.parent as RectTransform, eventData.position, UIMgr.Inst.UICamera, out var currentPosition);
                _lastPoint = currentPoint;
   
                
                //Debug.Log(TouchJudge(Input.mousePosition, ref _lastPoint, _anchor));
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _lastPoint = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y,
                Camera.main.transform.position.z > 0 ? Camera.main.transform.position.z : -Camera.main.transform.position.z));
            _anchor = transform.position;//鼠标点击 在点击位置下方设置偏移一定数值的圆心（具体偏移量看实际运用
            _dir = (_lastPoint - _anchor).normalized;
            _judge = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _judge = false;
        }
    }
}
