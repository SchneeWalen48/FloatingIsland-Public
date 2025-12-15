using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // video player 불러올 때 필요

// 2021.08.30 created by HY
// NEED : video(Rander Texture), video clip(video player)
// 비디오 조절하는 스크립트

public class VideoControllers : MonoBehaviour
{
    
    //public GameObject myVideo; // render texture
    public VideoPlayer videoClip; // video player
    public string nextSceneName; // hy : 다음 씬 이름 입력하기
    public float finishTime = 63.6f; // hy : 비디오 끝나는 시간
    public float skipTime = 58.55f; // hy : 비디오 스킵되는 시간
    public static bool isCredit = false;//크레딧, 디폴트는 꺼져있음, 엔딩 이후 켜짐.

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        // hy : video가 가장 끝에 오면 다음 씬으로 넘어간다.
        if(videoClip.time > finishTime)
        {
            //Debug.Log("다음 씬으로 넘어가기");
            videoClip.Pause();
            isCredit = true;
            SceneManager.LoadScene(nextSceneName);

        }
    }

    public void OnPlayVideo() // Play : 영상을 재생합니다.
    {
        //myVideo.SetActive(true);
        videoClip.Play();
    }

    public void OnPauseVideo() // Pause : 영상을 정지합니다.
    {
        //myVideo.SetActive(false);
        videoClip.Pause();
    }

    public void OnResetVideo()
    {
        videoClip.time = 0f; // time : 영상의 재생시점을 제어 가능합니다.
        videoClip.playbackSpeed = 1f;
    }

    public void OnFastVideo(float speed) // playbackspeed : 영상의 재생 속도를 제어합니다.
    {
        videoClip.playbackSpeed = speed;
    }

    //hy : 비디오 클립 Skip 버튼
    public void SkipVideo()
    {
        videoClip.time = skipTime; // hy : 비디오 클립 재생 시점을 가장 끝으로 만든다.
        videoClip.playbackSpeed = 1f;
        //Debug.Log("스킵 함수 실행");
        
    }

    public void ClickToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
