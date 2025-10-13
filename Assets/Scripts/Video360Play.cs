using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Video;

public class Video360Play : MonoBehaviour
{
    VideoPlayer vp;

    public VideoClip[] vcList; //리스트로 만들어서 여러 비디오 할당 가능
    int curVCidx;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx = 0; //현재 실행되고있는 비디오 클립의 인덱스
        vp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            curVCidx = curVCidx - 1;
            if (curVCidx < 0)
            {
                curVCidx = curVCidx + vcList.Length; //vsList에 있는 전체값 (3)
            }
            vp.clip = vcList[curVCidx];
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            curVCidx = curVCidx + 1;
            if (curVCidx >= vcList.Length)
            {
                curVCidx = curVCidx - vcList.Length; //vsList에 있는 전체값 (3)
            }
            vp.clip = vcList[curVCidx];
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            curVCidx = (curVCidx - 1 + vcList.Length) % vcList.Length;//나머지 연산
            vp.clip = vcList[curVCidx];
        }
    }
}
