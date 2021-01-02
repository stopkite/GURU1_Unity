using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스의 입력값을 이용해서 카메라를 회전하고싶다.
// - 마우스 이동의 누적값(x, y)
public class CameraRotate : MonoBehaviour
{
    // - 마우스 이동의 누적값(x, y)
    float rx;
    float ry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스의 입력값을 이용해서 카메라를 회전하고싶다.
        // 1. 마우스의 입력값을 받아오고싶다.
        float mx = Input.GetAxis("Mouse X");    // 마우스가 움직인 순간의 이동치값
        float my = Input.GetAxis("Mouse Y");

        rx += my;
        ry += mx;
        // 2. 그 값을 가지고 나의 회전값으로 사용하고싶다.
        transform.eulerAngles = new Vector3(-rx, ry, 0);
    }
}
