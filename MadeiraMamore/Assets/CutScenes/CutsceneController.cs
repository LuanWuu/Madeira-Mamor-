using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject MenuNight;
    [SerializeField] private GameObject SoundAmbiente;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Camera myCamera;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioSource secondSound;
    [SerializeField] private AudioSource musicAmbiente;
    [SerializeField] private DayTimeController dayController;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StaminaSystem staminaScript;
    [SerializeField] private Notification notificationScript;
    [SerializeField] private MoneySystem moneySystemScript;
    private AudioClip effect;
    private AudioClip secondEffect;
    private AudioClip music;
    private bool canAlarm;
    private bool isPlaying;
    private bool canGive;
    private bool? ear;
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
        SoundAmbiente.SetActive(true);
        HUD.SetActive(true);
        StartCoroutine(dayController.DayAnimator());
        SecondSound();
        Music();
        DecideMute();
        if(canAlarm == true){
            PlaySoundEffect();
        }
        if(DaySystem.dayTime == "Night" && DaySystem.day != 7){
            MenuNight.SetActive(true);
            playerValues.EnabledCursor();
        }
        if(canGive == true) {
            if(DaySystem.dayTime == "Morning") {
                canGive = false;
                staminaScript.IncreaseStamina(playerValues.staminaRecuperNight);
                StartCoroutine(staminaScript.IncreaseStamina(playerValues.staminaRecuperNight));
                playerValues.staminaRecuperNight = 0;
            }
            StartCoroutine(notificationScript.StartMovement());
            canGive = false;
        }
        if(playerValues.salary !=0) {
            StartCoroutine(moneySystemScript.GetSalary(playerValues.salary));
            playerValues.salary = 0;
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
        SoundAmbiente.SetActive(false);
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
    public void SecondeSoundEffect(AudioClip audio){
        secondEffect = audio;
    }
    void SecondSound(){
        secondSound.clip = secondEffect;
        secondSound.Play();
    }
    public void MusicAmbiente(AudioClip audio){
        music = audio;
    }
    void Music(){
        musicAmbiente.clip = music;
        musicAmbiente.Play();
    }
    public void MuteMusic(bool mute){
        musicAmbiente.mute = true;
        if(mute == true) {
            musicAmbiente.clip = null;
            musicAmbiente.mute = true;
        }else{
            ear = mute;
        }
    }
    void DecideMute(){
        musicAmbiente.mute = false;
        ear = null;
    }
}
