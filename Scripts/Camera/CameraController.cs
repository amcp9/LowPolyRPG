using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {
    public float maxScroll;
    public float minScroll;
    public float rotateSpeed;

    private Transform playerTransform;
    private Vector3 offsetPlayerPos;
    private float distance;
    private float scrollSpeed = 10;
    private Quaternion currentRotation;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(playerTransform);
        offsetPlayerPos = transform.position - playerTransform.position;
    }


    void Update()
    {
        transform.position = playerTransform.position + offsetPlayerPos;
        RotateCamera();
        ScrollView();
    }
    void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {

            transform.RotateAround(playerTransform.position, playerTransform.up, Input.GetAxis("Mouse X") * rotateSpeed);
            //更新玩家与摄像机的偏移信息
            offsetPlayerPos = transform.position - playerTransform.position;
            transform.position = playerTransform.position + offsetPlayerPos;
            //限制最大角度
            if (transform.localEulerAngles.x < 70 && Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(playerTransform.position, transform.right, -Input.GetAxis("Mouse Y") * rotateSpeed);
                //更新玩家与摄像机的偏移信息
                offsetPlayerPos = transform.position - playerTransform.position;
                transform.position = playerTransform.position + offsetPlayerPos;
            }
            //限制最小角度
            if (transform.localEulerAngles.x > 30 && Input.GetAxis("Mouse Y") > 0)
            {
                transform.RotateAround(playerTransform.position, transform.right, -Input.GetAxis("Mouse Y") * rotateSpeed);
                //更新玩家与摄像机的偏移信息
                offsetPlayerPos = transform.position - playerTransform.position;
                transform.position = playerTransform.position + offsetPlayerPos;
            }

        }
    }
    void ScrollView()
    {
        //限制最大缩放
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && offsetPlayerPos.magnitude < maxScroll && EventSystem.current.IsPointerOverGameObject() == false)
        {
            distance = offsetPlayerPos.magnitude;
            distance += System.Math.Abs(Input.GetAxis("Mouse ScrollWheel")) * scrollSpeed;
            offsetPlayerPos = offsetPlayerPos.normalized * distance;
        }
        //限制最小缩放
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && offsetPlayerPos.magnitude > minScroll&& EventSystem.current.IsPointerOverGameObject() == false)
        {
            distance = offsetPlayerPos.magnitude;
            distance += -System.Math.Abs(Input.GetAxis("Mouse ScrollWheel")) * scrollSpeed;
            offsetPlayerPos = offsetPlayerPos.normalized * distance;
        }
    }
}
