using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParabola2 : MonoBehaviour
{
    public Vector3 StartPos;//物体开始移动位置
    public Vector3 EndPos;//物体结束移动位置
    
    public bool IsUseTwoParabola = false;//是否使用两条曲线

    public float TotalTime;
    
    public float ParabolaA;
    
    //顶点高度
    public float VertexHeight;

    public float VertexWidthPercent;//顶点宽度百分比

    public float FirstParabolaTimePercent;//第一条曲线运动占的时长百分比
    // private float _firstParabolaTime;//第一段曲线运动的时长
    // private float _secondParabolaTime;//第二段曲线运动的时长
    // public float TotalTime;//总时长

    private ParabolaCoefficient _firstParabola =new ParabolaCoefficient();//第一条移动曲线
    private ParabolaCoefficient _secondParabola = new();//第二条移动曲线
    
    private bool _isStart = false;

    private LineRenderer _testRender;

    private void Start()
    {
        _testRender = GetComponent<LineRenderer>();
    }

    public void InitOnMultiParabola(Vector3 startPos, Vector3 endPos, float vertexHeight, float firstWidthPercent,
        float firstTimePercent, float totalTime)
    {
        StartPos = startPos;
        EndPos = endPos;
        //TotalTime = totalTime;
        
        FirstParabolaTimePercent = firstTimePercent;
        
        IsUseTwoParabola = true;
        float vertexX = startPos.x + (endPos.x - startPos.x) * firstWidthPercent;
        float vertexZ = startPos.z + (endPos.z - startPos.z) * firstWidthPercent;

        Vector3 vertex = new Vector3(vertexX, startPos.y + vertexHeight, vertexZ);

        
        // _firstParabolaTime = totalTime * firstWidthPercent;
        // _secondParabolaTime = totalTime * (1 - firstTimePercent);
        
        //设置两段运动曲线的参数
        _firstParabola.SetCoefficientByMultiParabola(vertex, startPos, totalTime * firstWidthPercent, true);
        _secondParabola.SetCoefficientByMultiParabola(vertex, endPos, totalTime * (1 - firstTimePercent), false);
    }

    public void InitOnSingleParabola(Vector3 startPos, Vector3 endPos, float parabolaA, float totalTime)
    {
        StartPos = startPos;
        EndPos = endPos;
        
        IsUseTwoParabola = false;
        _firstParabola.SetCoefficientBySingleParabola(parabolaA, startPos, endPos, totalTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (IsUseTwoParabola)
            {
                InitOnMultiParabola(StartPos,EndPos,VertexHeight,VertexWidthPercent,FirstParabolaTimePercent,TotalTime);
            }
            else
            {
                InitOnSingleParabola(StartPos, EndPos, ParabolaA, TotalTime);
            }

            transform.position = StartPos;
            _isStart = true;
        }

        if (_isStart)
        {
            
            if (IsUseTwoParabola)
            {
                Vector3 pos;
                if (!_firstParabola.IsMoveComplete)
                {
                    pos = _firstParabola.CountCurTimePos(Time.deltaTime);
                    transform.position = pos;
                }
                else if (!_secondParabola.IsMoveComplete)
                {
                    pos = _secondParabola.CountCurTimePos(Time.deltaTime);
                    transform.position = pos;
                }

                if (_firstParabola.IsMoveComplete && _secondParabola.IsMoveComplete)
                {
                    _isStart = false;
                    transform.position = EndPos;
                }
            }
            else
            {
                var pos = _firstParabola.CountCurTimePos(Time.deltaTime);
                transform.position = pos;
                if (_firstParabola.IsMoveComplete)
                {
                    _isStart = false;
                    transform.position = EndPos;
                }
            }

            AddPoint();
            // if (_curTime >= TotalTime)
            // {
            //     _isStart = false;
            //     transform.position = EndPos;
            // }
        }
    }
    
    private void AddPoint()
    {
        _testRender.positionCount += 1;
        _testRender.SetPosition(_testRender.positionCount - 1, transform.position);
    }
}

/// <summary>
/// 抛物线决定系数
/// 根据抛物线公式 y=ax^2+bx+c 抛物线顶点计算公式（h,k) h=-b/2a k=(4ac-b^2)/4a 由策划设置顶点位置 求出抛物线系数
/// </summary>
public class ParabolaCoefficient
{
    private Vector3 _vertexPos;
    private Vector3 _originPos;

    private bool _isOriginStart;//true: originPos为起点坐标 false: originPos为终点坐标

    private float _parabolaA;//抛物线公式系数a

    private float _parabolaB;//抛物线公式系数b

    private float _parabolaC;//抛物线公式系数c

    private float _speed;//X轴移动速度

    private float _totalMoveTime;//移动时间

    public bool IsMoveComplete { get; private set; } //是否移动完成

    private float _moveTime;

    private Vector2 _dirXZ;
    /// <summary>
    /// 涉及到多端位移曲线使用时
    /// </summary>
    /// <param name="vertexPos"></param>
    /// <param name="originPos"></param>
    /// <param name="moveTime"></param>
    /// <param name="isStartPos"></param>
    public void SetCoefficientByMultiParabola(Vector3 vertexPos,Vector3 originPos,float moveTime,bool isStartPos)
    {
        this._vertexPos = vertexPos;
        this._originPos = originPos;
        this._isOriginStart = isStartPos;
        this._totalMoveTime = moveTime;

        Vector2 startXZ = new Vector2(originPos.x, originPos.z);
        Vector2 vertexXZ = new Vector2(vertexPos.x, vertexPos.z);
        float startX = startXZ.magnitude;
        float vertexX = vertexXZ.magnitude;
        //根据y=ax^2+bx+c 以及顶点(h,k)公式h=-b/2a k=(4ac-b^2)/4ac 得出 a=(y-k)/(x-h)^2 b=-2ah c=ah^2+k;
        _parabolaA = (_originPos.y - _vertexPos.y) / Mathf.Pow((startX - vertexX), 2);
        _parabolaB = -2 * _parabolaA * vertexX;
        _parabolaC = _parabolaA * Mathf.Pow(vertexX, 2) + _vertexPos.y;

        _speed = Mathf.Abs(startX - vertexX) / _totalMoveTime;
        //如果OriginPos是起点 以顶点为终点计算速度 否则 以顶点为起点计算移动速度
        if (isStartPos)
        {
            // SpeedX = (VertexPos.x - OriginPos.x) / MoveTime;
            // SpeedZ = (VertexPos.z - OriginPos.z) / MoveTime;
            _dirXZ = (vertexXZ - startXZ).normalized;
        }
        else
        {

            // SpeedX = (OriginPos.x - VertexPos.x) / MoveTime;
            // SpeedZ = (OriginPos.z - VertexPos.z) / MoveTime;
            _dirXZ = (startXZ - vertexXZ).normalized;
        }

        IsMoveComplete = false;
        _moveTime = 0;
    }

    /// <summary>
    /// 当仅使用一条移动曲线时调用
    /// </summary>
    /// <param name="parabolaA"></param>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="totalTime"></param>
    public void SetCoefficientBySingleParabola(float parabolaA,Vector3 startPos,Vector3 endPos,float totalTime)
    {
        this._vertexPos = endPos;
        this._originPos = startPos;
        this._isOriginStart = true;
        this._totalMoveTime = totalTime;
        this._parabolaA = parabolaA;
        
        Vector2 startXZ = new Vector2(startPos.x, startPos.z);
        Vector2 vertexXZ = new Vector2(endPos.x, endPos.z);
        float startX = startXZ.magnitude;
        float vertexX = vertexXZ.magnitude;
        //根据已知系数A 以及公式 y=ax^2+bx+c 得出 b=(y1-y2)-a(x1^2-x2^2)/(x1-x2) 求出b带入公式得出c
        _parabolaB =
            ((_vertexPos.y - _originPos.y) - _parabolaA * (Mathf.Pow(vertexX, 2) - Mathf.Pow(startX, 2))) /
            (vertexX - startX);
        _parabolaC = _originPos.y - _parabolaA * Mathf.Pow(startX, 2) - _parabolaB * startX;

        _dirXZ = (vertexXZ - startXZ).normalized;
        _speed = Mathf.Abs(vertexX - startX) / totalTime;
        // SpeedX = (VertexPos.x - OriginPos.x) / totalTime;
        // SpeedZ = (VertexPos.z - OriginPos.z) / totalTime;

        IsMoveComplete = false;
        _moveTime = 0;
    }

    /// <summary>
    /// 计算当前时间在移动曲线上的位置
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <returns></returns>
    public Vector3 CountCurTimePos(float deltaTime)
    {
        _moveTime += deltaTime;
        if (_moveTime >= _totalMoveTime)
        {
            IsMoveComplete = true;
            return _isOriginStart ? _vertexPos : _originPos;
        }
        
        var startPos = _isOriginStart ? _originPos : _vertexPos;

        var xz = _speed * _moveTime * _dirXZ;
        xz.x += startPos.x;
        xz.y += startPos.z;
        float curY = _parabolaA * Mathf.Pow(xz.magnitude, 2) + _parabolaB * xz.magnitude + _parabolaC;

        return new Vector3(xz.x, curY, xz.y);
    }
}
