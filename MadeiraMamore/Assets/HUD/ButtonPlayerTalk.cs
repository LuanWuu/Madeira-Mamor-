using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPlayerTalk : MonoBehaviour, IPointerDownHandler
{
    [System.NonSerialized] public MensageController mensageControllerScript;
    [SerializeField] private roadMap characterWords;
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
    }
    void HaveAnswer(){
        if(localSignal == true){
            mensageControllerScript.AnswerPositive();
        }else if(localSignal == false){
            mensageControllerScript.AnswerNegative();
        }
    }
}
