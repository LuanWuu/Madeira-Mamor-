using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] creditisText; // 0 1 2
    private int number;
    public void Next(){
        if(number < 2) {
            number++;
        }else{
            number = 0;
        }
        CreditsNext(number);
    }
    public void Back(){
        if(number > 0) {
            number--;
        }else{
            number = 2;
        }
        CreditsBack(number);
    }
    void CreditsNext(int number){
        creditisText[number].SetActive(true);
        if(number != 0) {
            creditisText[number-1].SetActive(false); 
        }else{
            creditisText[2].SetActive(false); 
        }
    }
    void CreditsBack(int number){
        creditisText[number].SetActive(true);
        if(number != 2) {
            creditisText[number+1].SetActive(false); 
        }else{
            creditisText[0].SetActive(true); 
        }
    }
}
