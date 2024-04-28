using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA : MonoBehaviour
{
    public float time=3;//代表从A点出发到B经过的时长
    public Vector3 pointA;//点A
    public Vector3 pointB;//点B
    public float g=-10;//重力加速度
    // Use this for initialization
    private Vector3 speed;//初速度向量
    private Vector3 Gravity;//重力向量

    private LineRenderer _testRender;
    void Start ()
    {

        _testRender = GetComponent<LineRenderer>();
        transform.position = pointA;//将物体置于A点
        //通过一个式子计算初速度
        speed = new Vector3((pointB.x - pointA.x)/time,
            (pointB.y-pointA.y)/time-0.5f*g*time, (pointB.z - pointA.z) / time);
        Gravity = Vector3.zero;//重力初始速度为0
    }
    private float dTime=0;

    private void Update()
    {
        if (dTime < time)
        {
            Gravity.y = g * (dTime += Time.deltaTime);//v=at
            //模拟位移
            transform.Translate(speed*Time.deltaTime);
            transform.Translate(Gravity * Time.deltaTime);
            AddPoint();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {


    }
    
    private void AddPoint()
    {
        _testRender.positionCount += 1;
        _testRender.SetPosition(_testRender.positionCount - 1, transform.position);
    }
}
