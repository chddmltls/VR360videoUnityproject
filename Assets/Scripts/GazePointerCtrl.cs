using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GazePointerCtrl : MonoBehaviour
{
    public Transform uiCanvas; //ĵ����
    public UnityEngine.UI.Image gazeImg; //ĵ������ �鰥 �̹���

    Vector3 defalutScale;
    public float uiScaleVal = 1f;

    bool isHitObj;
    GameObject preHitObj;
    GameObject curHitObj;
    //float curGazeTime;
    public float gazeChargeTime = 3.0f;
    float curGazeTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        defalutScale = uiCanvas.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // ĵ���� ������Ʈ�� �������� �Ÿ��� ���� ����
        // 1. ī�޶� �������� ���� ������ ��ǥ ���� ��� (����)
        Vector3 dir = transform.TransformPoint(Vector3.forward);
        // 2. ī�޶� �������� Ray����
        Ray ray = new Ray(transform.position, dir); //������ �� �������� ���̸� ��
        RaycastHit hitInfo;
        // 3. ���̿� �΋H�� ��� �Ÿ����̿��� uiCanvas�� ũ�⸦ ����
        if (Physics.Raycast(ray, out hitInfo))
        {
            uiCanvas.localScale = defalutScale * uiScaleVal * hitInfo.distance;
            uiCanvas.position = transform.forward * hitInfo.distance;
            if (hitInfo.transform.tag == "GazeObj")
            {
                isHitObj = true;
            }
            curHitObj = hitInfo.transform.gameObject;
        }
        else // 4. �浹 �߻� ���ϴ� ��� -> �⺻ ������ ������ uiCanvasũ�� ����
        {
            uiCanvas.localScale = defalutScale * uiScaleVal;
            uiCanvas.position = transform.position + dir;
        }
        // 5. uiCanvas�� ����ڸ� �ٶ󺼼� �ֵ��� ���� (���� ������ �ݴ�� �ٲٱ�)
        uiCanvas.forward = uiCanvas.forward * -1;

        //������ ó��
        if (isHitObj)
        {
            if (curHitObj == preHitObj) //�浹�� �ٶ󺸴°� ������ -> �ٶ󺸰������� ������
            {
                curGazeTime = curGazeTime + Time.deltaTime;
            }
            else
            {
                preHitObj = curHitObj;
            }
            HitObjChecker(curHitObj, true);
        }
        else //������Ʈ�� �ٶ󺸰� ���� ������
        {
            curGazeTime = 0;
            if(preHitObj != null)
            {
                HitObjChecker(curHitObj, false);
                preHitObj = null;
            }
        }

        curGazeTime = Mathf.Clamp(curGazeTime, 0, gazeChargeTime); //�ּ� �ִ� ���� ���
        gazeImg.fillAmount = curGazeTime / gazeChargeTime; //0 ~ 100% ��ǥ�h

        //������ ���� �ļ� ��ġ
        isHitObj = false; //���� Ʈ�簡 ��� ���������� �����Ƿ�
        curHitObj = null; //���纸�� ������Ʈ ��� �����
    }

    void HitObjChecker(GameObject hitObj, bool isActive)
    {
        if (hitObj.GetComponent<VideoFrame>())
        {
            if (isActive)
            {
                hitObj.GetComponent<VideoFrame>().CheckVideoFrame(true);
            }
            else
            {
                hitObj.GetComponent<VideoFrame>().CheckVideoFrame(false);
            }
        }
    }
}
