using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 抛物线公式 y=ax^2+bx+c 抛物线顶点（h,k) h=-b/2a k=(4ac-b^2)/4a 由策划给出A 根据起点和终点计算出当前抛物线的公式
/// </summary>
public class TestParabola : MonoBehaviour
{
    public Vector3 StartPos;//物体开始移动位置
    public Vector3 EndPos;//物体结束移动位置
    
    public float parabolaA;//抛物线公式系数a

    public float TotalTime;//总时长

    public bool IsLinerFall = false;//是否为直线下落
    
    private float parabolaB;//抛物线公式系数b

    private float parabolaC;//抛物线公式系数c

    private bool _isStart = false;

    private float _speedX;//X轴移动速度

    private float _speedZ;//Z轴移动速度
    
    private float _time;//移动总时长

    private Vector3 _dir;//朝向

    private LineRenderer _testRender;

    //抛物线顶点坐标
    private float _vertexX;//顶点X位置

    private float _vertexY;//顶点Y位置

    private float _toVertexTime;//移动到顶点的时间

    private float _uniformYPos;

    #region 直线下落数据

    private float _speedY;//匀速直线下落速度
    private float _yAccumulate;//做匀加速运动时向下的加速度
    private float _accumulateTime;//做加速的时间
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _testRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = StartPos;
            CountBC();
            _isStart = true;
            _time = 0;
        }

        if (_isStart)
        {
            if (_time >= TotalTime)
            {
                transform.position = EndPos;
                _isStart = false;
                return;
            }

            //var curPos = StartPos + _speedX * _time * _dir;
            float curZ = StartPos.z + _speedZ * _time;
            //float curX = new Vector2(curPos.x, curPos.z).magnitude;
            float curX = StartPos.x + _speedX * _time;
            float curY = parabolaA * Mathf.Pow(curX,2) + parabolaB * curX + parabolaC;
           // float curZ = _speedZ * _time;
           //如果当前已经移动到了顶点且接下来需要匀速下落
           if (_time >= _toVertexTime && IsLinerFall)
           {
               curY = _vertexY + _yAccumulate * Mathf.Pow(_time - _toVertexTime, 2) * 0.5f;
           }
            
            _time += Time.deltaTime;
            var curPos = new Vector3(curX, curY, curZ);
            transform.position = curPos;
            AddPoint();
        }
    }

    private void CountBC()
    {
         // float startX = (new Vector2(StartPos.x, StartPos.z)).magnitude;
         // float endX = (new Vector2(EndPos.x, EndPos.z)).magnitude;

         float startX = StartPos.x;
         float endX = EndPos.x;
         
        _dir = (EndPos - StartPos).normalized;
        //var dis = Vector2.Distance(new Vector2(StartPos.x, StartPos.z), new Vector2(EndPos.x, EndPos.z));
        _speedX = (EndPos.x - StartPos.x) / TotalTime;
        _speedZ = (EndPos.z - StartPos.z) / TotalTime;
        
        //计算抛物线公式系数
        parabolaB = ((EndPos.y - StartPos.y) - parabolaA * (Mathf.Pow(endX,2) - Mathf.Pow(startX,2))) / (endX - startX);
        parabolaC = EndPos.y - parabolaA * Mathf.Pow(endX,2) - parabolaB * endX;
        
        //计算抛物线顶点坐标
        _vertexX = -parabolaB / (2 * parabolaA);
        _vertexY = (4 * parabolaA * parabolaC - Mathf.Pow(parabolaB, 2)) / (4 * parabolaA);

        //parabolaVertex = new Vector2(vertexX, vertexY);
        //计算运动到抛物线顶点需要的时间
        _toVertexTime = (_vertexX - StartPos.x) / _speedX;
        //计算从顶点开始Y轴从速度0开始的加速度
        float fallTime = (TotalTime - _toVertexTime);//动顶点开始的下落时间
        _yAccumulate = (EndPos.y - _vertexY) * 2 / Mathf.Pow(fallTime, 2);
    }
    
    private void AddPoint()
    {
        _testRender.positionCount += 1;
        _testRender.SetPosition(_testRender.positionCount - 1, transform.position);
    }
}
