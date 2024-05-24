using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private roadMap roadMapController;
    [SerializeField] private MensageController mensageControllerScript;
    [SerializeField] private string[] dayTime;
    [SerializeField] private GameObject train;
    [SerializeField] private GameObject bed;
    [SerializeField] private GameObject DayIcon;
    [SerializeField] private GameObject mornig;
    [SerializeField] private GameObject afternoon;
    [SerializeField] private GameObject night;
    [SerializeField] private TextMeshProUGUI DayText;

    private VideoPlayer videoPlayer;
    public GameObject VideoCamera;
    public AudioSource MainCamera;
    public GameObject Hud;
    public VideoClip cutscene1;
    public VideoClip cutscene2;
    public VideoClip end1;
    public VideoClip end2;
    public VideoClip end3;
    public VideoClip transition;
    public AudioClip Mosquito;
    public AudioClip Chuva;
    public AudioClip Trem;
    public AudioSource sound;

    private bool cutscene = true;

    void Awake()
    {
        //Cutscenes
        videoPlayer = GetComponent<VideoPlayer>();

        DaySystem.day = 1;
        ChangedDay();
        TimeOfDay(0);
        roadMapController.SpecialNight1();
        roadMapController.NotWords();
        roadMapController.ChefWords();
        StartCoroutine(DayAnimator());
    }

    IEnumerator DayAnimator(){
        DayIcon.SetActive(true);
        yield return new WaitForSeconds(4);
        DayIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Cutscenes
        if (videoPlayer.isPlaying)
        {
            VideoCamera.gameObject.SetActive(true);
            Hud.gameObject.SetActive(false);       
        }
        else
        {
            VideoCamera.gameObject.SetActive(false);
            Hud.gameObject.SetActive(true);         
        }

        if(cutscene == true)
        {
            MainCamera.mute = true;
        }
        else
        {
            MainCamera.mute = false;
        }

        //pausar


        if (Input.GetKeyDown("l")){
            DaySystem.day++;
            ChangedDay();
        }
        if(Input.GetKeyDown("j")){
                  Debug.Log("DaySystem.dayTime " + DaySystem.dayTime);  
        }
    }
    public void TimeOfDay(int moment){
        for(int i = 0; i < dayTime.Length; i++) {
            if(i == moment) {
                DaySystem.dayTime = dayTime[i];
                break;
            }
        }
        switch(DaySystem.dayTime){
            case "Morning":               
                train.SetActive(true);
                roadMapController.ChefWords();
                mornig.SetActive(true);
                afternoon.SetActive(false);
                night.SetActive(false);
                break;
            case "Lunch":              
                roadMapController.ChefWords();
                break;
            case "Afternoon":
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                //==
                mornig.SetActive(false);
                afternoon.SetActive(true);
                night.SetActive(false);
                break;
            case "Night":
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                sound.clip = Trem;
                sound.Play();
                //==
                train.SetActive(false);
                roadMapController.ChefOrders();
                bed.SetActive(true);
                mornig.SetActive(false);
                afternoon.SetActive(false);
                night.SetActive(true);
                break;
            default:
                    break;
        }
    }
    public void ChangedDay(){
        mensageControllerScript.moment = 0;
        switch(DaySystem.day){
            case 1:
                //cutscene 1
                cutscene = true;
                videoPlayer.clip = cutscene1;
                Invoke("PlayVideo", 0f);
                Invoke("FinishCutscene", 30f);
                //==
                roadMapController.InitializeWorkerTalkDay1();
                DayText.text = "Dia " + DaySystem.OrderDay[0].ToString();
                break;
            case 2:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                sound.clip = Mosquito;
                sound.Play();
                //==
                roadMapController.InitializeWorkerTalkDay2();
                DayText.text = "Dia " + DaySystem.OrderDay[1].ToString();
                break;
            case 3:
                //cutscene 2
                cutscene = true;
                videoPlayer.clip = cutscene2;
                Invoke("PlayVideo", 0f);
                Invoke("FinishCutscene", 30f);
                //==
                roadMapController.InitializeWorkerTalkDay12();
                DayText.text = "Dia " + DaySystem.OrderDay[2].ToString();
                break;
            case 4:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                sound.clip = Chuva;
                sound.Play();
                //==
                roadMapController.InitializeWorkerTalkDay20();
                DayText.text = "Dia " + DaySystem.OrderDay[3].ToString();
                break;
            case 5:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                //==
                roadMapController.InitializeWorkerTalkDay22();
                DayText.text = "Dia " + DaySystem.OrderDay[4].ToString();
                break;
            case 6:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                //==
                roadMapController.InitializeWorkerTalkDay25();
                DayText.text = "Dia " + DaySystem.OrderDay[5].ToString();
                break;
            case 7:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                //==
                roadMapController.InitializeWorkerTalkDay26();
                DayText.text = "Dia " + DaySystem.OrderDay[6].ToString();
                break;
            case 8:
                //transition
                cutscene = false;
                videoPlayer.clip = transition;
                Invoke("PlayVideo", 0f);
                //==
                roadMapController.InitializeWorkerTalkDay27();
                DayText.text = "Dia " + DaySystem.OrderDay[7].ToString();
                break;
            case 9:
                //não deixar dia aparecer
                //ending 1
                videoPlayer.clip = end1;
                Invoke("PlayVideo", 0f);
                //==
                DayText.text = "Dia " + DaySystem.OrderDay[8].ToString();
                Invoke("EndGame", 30);
                break;
            default:
                break;
        }
 
        mensageControllerScript.PickWorkerWords();
        
        StartCoroutine(DayAnimator());
    }
    void EndGame(){
        SceneManager.LoadScene("EndGame");
    }

    //Cutscenes
    public void PlayVideo ()
    {
        videoPlayer.Play();
    }
    public void FinishCutscene()
    {
        cutscene = false;
    }
}
