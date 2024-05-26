using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndGame : MonoBehaviour
{
    [SerializeField] private DatabaseCutscene database;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string nameScene;
    void Start(){
        PlayVideo();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void OnVideoEnd(VideoPlayer vp){
        SceneManager.LoadScene(nameScene);
    }

    void OnVideoPrepared(VideoPlayer vp){
        videoPlayer.frame = 0;
        vp.Play();
    }
    void PlayVideo(){
        videoPlayer.clip = database.chosenEnding;
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
        videoPlayer.frame = 0;
    }
}
