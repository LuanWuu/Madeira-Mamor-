using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "Cutscene", menuName = "DatabaseCutscene")]
public class DatabaseCutscene : ScriptableObject
{ 
    public VideoClip cutscene1;
    public VideoClip cutscene2;
    public VideoClip end1;
    public VideoClip end2;
    public VideoClip end3;
    public VideoClip chosenEnding;
    public VideoClip transition;
    public AudioClip Chuva;
    public AudioClip Trem;
    public AudioClip Alarm;
    public AudioClip workSound;
    public AudioClip lunchMoment;
    public AudioClip ambiance;
    public AudioClip night;
    public AudioClip betSound;
    public AudioClip mosquito;
    public AudioClip hitWood;
    public AudioClip brokenWood;
}
