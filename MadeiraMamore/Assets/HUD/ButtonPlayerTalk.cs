using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonPlayerTalk : MonoBehaviour, IPointerDownHandler
{
    [System.NonSerialized] public MensageController mensageControllerScript;
    [SerializeField] private roadMap characterWords;
    [SerializeField] private TMP_Text buttonText;
    public bool localSignal;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(characterWords.answer == false){
            mensageControllerScript.ChangePhrase();
        }else if(characterWords.answer == true){
            HaveAnswer();
        }
        buttonText.text = "Próximo";
    }
    void HaveAnswer(){
        if(localSignal == true){
            mensageControllerScript.AnswerPositive();
        }else if(localSignal == false){
            mensageControllerScript.AnswerNegative();
        }
    }
    public void buttonNext(List<string> button){
         buttonText.text = button[2];
    }
    public void PlayerAnswersButtons(List<string> playerQuestAnswer){
        if(localSignal == true){
            buttonText.text = playerQuestAnswer[1];
        }else if(localSignal == false){
            buttonText.text = playerQuestAnswer[0];
        }
    }
}
