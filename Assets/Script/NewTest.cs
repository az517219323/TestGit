using System.Collections;
using System.Collections.Generic;
using pff.Homestead;
using UnityEngine;

public class NewTest : MonoBehaviour
{
    
    public AnimationCurve curve;
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float duration = 2f;

    private LineRenderer _testRender;
    void Start()
    {
        _testRender = GetComponent<LineRenderer>();
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        float time = 0f;
        while (time <= duration)
        {
            float t = time / duration;
            Vector3 currentPoint = Vector3.Lerp(startPoint, endPoint, t);
            currentPoint.y += curve.Evaluate(t);
            transform.position = currentPoint;
            AddPoint();
            time += Time.deltaTime;
            yield return null;
        }
    }
    // public AnimationCurve UpSpeedCurve;
    //
    // //public AnimationCurve FallSpeedCurve;
    //
    // public Vector3 StartPos;
    //
    // public Vector3 EndPos;
    //
    // public float TopPercent;//最高点占整个位移的百分比
    // //public float Heightest;//最高点相对位移高度
    // private Vector3 _topPos;//抛物线最高点
    // public float XStartSpeed;
    //
    // public float YStartSpeed;
    // public float YEndSpped;
    //
    // private float upTime;
    //
    // private float downTime;
    //
    // private float totalTime;
    // private float _moveTime;
    // private Vector3 _dir;
    //
    // private bool _isStart = false;
    //
    // private LineRenderer _testRender;
    // private ObjectFalling _objectFalling;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     _objectFalling = GetComponent<ObjectFalling>();
    //     //_objectFalling.Init(new Vector3(5, 10, 0), new Vector3(20, 5, 0), null, 5);
    //     _dir = (EndPos - StartPos).normalized;
    //     totalTime = (EndPos.x - StartPos.x) / XStartSpeed;
    //     upTime = (EndPos.x - StartPos.x) / XStartSpeed * TopPercent;
    //     downTime = (EndPos.x - StartPos.x) / XStartSpeed * (1 - TopPercent);
    //     _testRender = GetComponent<LineRenderer>();
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Alpha0))
    //     {
    //         // transform.position = StartPos;
    //         // _isStart = true;
    //         // _testRender.positionCount = 0;
    //         // _moveTime = 0;
    //         _objectFalling.Init(StartPos, EndPos, null, 2, 5);
    //     }
    //     
    //     // if (_isStart)
    //     // {
    //     //     if (_moveTime >= totalTime)
    //     //     {
    //     //         _isStart = false;
    //     //     }
    //     //     //_objectFalling.Init(new Vector3(5, 10, 0), new Vector3(20, 5, 0), null, 5);
    //     //     var move = _dir * (XStartSpeed * Time.deltaTime);
    //     //     // if (_moveTime <= upTime)
    //     //     // {
    //     //         var cp = UpSpeedCurve.Evaluate(_moveTime);
    //     //         var curSpeed = cp * YStartSpeed;
    //     //         move.y = curSpeed * Time.deltaTime;
    //     //     // }
    //     //     // else
    //     //     // {
    //     //     //     //var cp = FallSpeedCurve.Evaluate((_moveTime - upTime) / downTime);
    //     //     //     var curSpeed = Mathf.Lerp(0, YEndSpped, cp);
    //     //     //     move.y = curSpeed * Time.deltaTime;
    //     //     // }
    //     //
    //     //     _moveTime += Time.deltaTime;
    //     //     transform.position += move;
    //     //     AddPoint();
    //     // }
    // }
    
    private void AddPoint()
    {
        _testRender.positionCount += 1;
        _testRender.SetPosition(_testRender.positionCount - 1, transform.position);
    }
}
