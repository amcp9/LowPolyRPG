using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : Singleton<MouseManager>
{
    public delegate void Click(GameObject go);
    public event Click OnLeftClick;//鼠标左键事件
    public event Click OnMouse;//鼠标悬停事件
    public event Click OnRightClick;//鼠标右键事件


    private float hoverTime = 0;//悬停时间
    private Vector3 tempPos;//临时存储鼠标位置的vector 3


    private void Update()
    {
        JudgeStop();//判断是否移动
        if (hoverTime >= 2)//鼠标悬停2秒
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 10);
            if (hit.collider)
            {
                if (OnMouse != null)
                {
                    //发布事件
                    OnMouse(hit.transform.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider && EventSystem.current.IsPointerOverGameObject()==false)
            {
                if (OnLeftClick != null)
                {
                    //发布事件
                    OnLeftClick(hit.transform.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider && EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (OnRightClick != null)
                {
                    //发布事件
                    OnRightClick(hit.transform.gameObject);
                }
            }
        }
        tempPos = Input.mousePosition;//获取这一帧中的鼠标位置
    }

    private void JudgeStop()
    {
        //与上一帧中的鼠标对比判断是否移动
        if (tempPos == Input.mousePosition)
        {
            //悬停时间增加
            hoverTime += Time.deltaTime;
        }
        if(EventSystem.current.IsPointerOverGameObject() == false)
        {
            hoverTime = 0;
        }
        else { hoverTime = 0; }
    }
}
