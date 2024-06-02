using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private Image tutorialImage;
    [SerializeField] private Sprite[] spritesTutorial;
    [SerializeField] private CutsceneController cutscene;
    [SerializeField] private DatabaseCutscene database;
    [SerializeField] private ScrpitTablePlayer playerValues;
    public void Active(){
        playerValues.EnabledCursor();
        Time.timeScale = 0;
        gameObject.SetActive(true);
        if(DaySystem.day != 6) {
            switch(DaySystem.dayTime){
                case "Morning":
                    tutorialImage.sprite = spritesTutorial[0];
                    break;
                case "Afternoon":
                     tutorialImage.sprite = spritesTutorial[1];
                    break;
            }  
        }else{
            tutorialImage.sprite = spritesTutorial[2];
        }
    }
    public void ButtonTutoral(){
        playerValues.DisabledCursor();
        cutscene.PlayVideo(database.transition);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
