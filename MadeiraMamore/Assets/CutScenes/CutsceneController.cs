using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject video;
    [SerializeField] private GameObject HUD;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource ambianceSound;
    [SerializeField] private DayTimeController dayController;
    //[SerializeField] private DayTimeController
    private long totalFrames;
    private AudioClip effect;
    private AudioClip ambiance;
    private void Start() {
         videoPlayer.Prepare();
    }
    void OnVideoEnd(VideoPlayer vp){
        videoPlayer.gameObject.SetActive(false);
        ambianceSound.mute = false;
        HUD.SetActive(true);
        StartCoroutine(dayController.DayAnimator());
        PlaySoundEffect();
        Ambiance();
    }

    void OnVideoPrepared(VideoPlayer vp){
        videoPlayer.frame = 0;
        vp.Play();
    }
    public void PlayVideo(VideoClip cutscene) {
        video.SetActive(true);
        Debug.Log("teste");
        ambianceSound.mute = true;
        HUD.SetActive(false);
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
        videoPlayer.frame = 0;
    }

    public void SoundEffect(AudioClip audio){
        effect = audio;
    }
    void PlaySoundEffect(){
        sound.clip = effect;
        sound.Play();
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
