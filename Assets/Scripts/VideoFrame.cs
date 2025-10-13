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
        //영상재생을 멈춤
        vp.Play(); //Video Frame에 있는 Video player의 영상을 멈추고 싶음
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            vp.Stop();
        }


        //영상 재생
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
    
    public void CheckVideoFrame(bool Checker) //게이즈포인터컨트롤에서 영상 재생을 컨트롤하기 위한 함수
    {
        if (Checker)
        {
            if (!vp.isPlaying) //재생하지 않는다면 재생 (!)
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
