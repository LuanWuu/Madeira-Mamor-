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
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StaminaSystem staminaScript;
    private AudioClip effect;
    private AudioClip ambiance;
    private bool canAlarm;
    private bool isPlaying;
    private bool canGive;
    private void Start() {
         videoPlayer.Prepare();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isPlaying) {
            videoPlayer.frame = (long)videoPlayer.frameCount - 1;
        }
    }
    void OnVideoEnd(VideoPlayer vp){
        myCamera.enabled = false;
        cameraMain.enabled = true;
        isPlaying = false;
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
            playerValues.EnabledCursor();
        }
        if(DaySystem.dayTime == "Night"){
            MenuNight.SetActive(true);
            playerValues.EnabledCursor();
        }
        if(DaySystem.dayTime == "Morning" && canGive == true) {
            canGive = false;
            Debug.Log("stamanuda");
            StartCoroutine(staminaScript.IncreaseStamina(playerValues.staminaRecuperNight));
            playerValues.staminaRecuperNight = 0;
        }
    }

    void OnVideoPrepared(VideoPlayer vp){
        videoPlayer.frame = 0;
        vp.Play();
        isPlaying = true;
    }
    public void PlayVideo(VideoClip cutscene){
        myCamera.enabled = true;
        cameraMain.enabled = false;
        canGive = true;
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
