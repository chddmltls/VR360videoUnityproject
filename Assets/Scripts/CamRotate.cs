using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 입력에 따라 카메라를 회전하는 코드
// 필요한 속성: 현재 각도 및 마우스 감도.
public class CamRotate : MonoBehaviour
{
    Vector3 angle; //현 각도
    public float sensitivity = 200; //마우스 민감도
    void Start()
    {
        //시작할때 현재 카메라의 각도 적용
        angle = Camera.main.transform.eulerAngles;
        angle.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse Y"); //마우스의 좌우 입력 받기
        float y = Input.GetAxis("Mouse X");

        angle.x = angle.x + x * sensitivity * Time.deltaTime; //이동 공식에 대입해 각 속성별로 회전 값을 누적시킴
        angle.y = angle.y + y * sensitivity * Time.deltaTime; //Time.deltaTime은 프레임 사이의 시간을 의미함
        angle.z = transform.eulerAngles.z; 

        angle.x = Mathf.Clamp(angle.x, -90, 90); //Clamp = 최솟값 및 최댓값을 정해줄 수 있음. 이 경우 카메라의 각도제한을 90도 까지만 해준것.
        transform.eulerAngles = new Vector3(-angle.x, angle.y, angle.z); //적용 대상의 위치 정보 정의해줌(transform)
    }
}
