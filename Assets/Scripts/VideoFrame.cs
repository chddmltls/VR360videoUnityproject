using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFrame : MonoBehaviour
{
    VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        //��������� ����
        vp.Play(); //Video Frame�� �ִ� Video player�� ������ ���߰� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            vp.Stop();
        }


        //���� ���
        if (Input.GetKeyDown("space"))
        {
            if (vp.isPlaying)
            {
                vp.Pause();
            }

            if (vp.isPaused)
            {
                vp.Play();
            }
        }
    }
    
    public void CheckVideoFrame(bool Checker) //��������������Ʈ�ѿ��� ���� ����� ��Ʈ���ϱ� ���� �Լ�
    {
        if (Checker)
        {
            if (!vp.isPlaying) //������� �ʴ´ٸ� ��� (!)
            {
                vp.Play();
            }
        }
        else
        {
            vp.Stop();
        }
    }
}
