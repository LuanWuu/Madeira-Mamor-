using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject MenuNight;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Camera myCamera;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource ambianceSound;
    [SerializeField] private DayTimeController dayController;
    [SerializeField] private StoragaDayValues DaySystem;
    private AudioClip effect;
    private AudioClip ambiance;
    private bool canAlarm;
    private void Start() {
         videoPlayer.Prepare();
    }
    void OnVideoEnd(VideoPlayer vp){
        myCamera.enabled = false;
        cameraMain.enabled = true;
        videoPlayer.gameObject.SetActive(false);
        HUD.SetActive(true);
        ambianceSound.mute = false;
        StartCoroutine(dayController.DayAnimator());
        Ambiance();
        if(canAlarm == true){
            PlaySoundEffect();
        }
        if(DaySystem.dayTime == "Night"){
            MenuNight.SetActive(true);
        }
    }

    void OnVideoPrepared(VideoPlayer vp){
        videoPlayer.frame = 0;
        vp.Play();
    }
    public void PlayVideo(VideoClip cutscene){
        myCamera.enabled = true;
        cameraMain.enabled = false;
        videoPlayer.gameObject.SetActive(true);
        HUD.SetActive(false);
        ambianceSound.mute = true;
        videoPlayer.clip = cutscene;
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
        videoPlayer.frame = 0;
    }

    public void SoundEffect(AudioClip audio){
        canAlarm = true;
        effect = audio;
    }
    void PlaySoundEffect(){
        sound.clip = effect;
        sound.Play();
        canAlarm = false;
    }
    public void GiveAmbianceSound(AudioClip audio){
        ambiance = audio;
    }
    void Ambiance(){
        ambianceSound.mute = false;
        ambianceSound.clip = ambiance;
        ambianceSound.Play();
    }
    
}
