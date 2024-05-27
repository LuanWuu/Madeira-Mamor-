using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bet : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private MoneySystem moneyScript;
    [SerializeField] private NighthChoses NighthChosesScript;
    [SerializeField] private TextMeshProUGUI ChoseNumberText;
    [SerializeField] private TextMeshProUGUI betText;
    [System.NonSerialized] public int valueBet = 0;
    [System.NonSerialized] public int valueTextBet = 0;
    [SerializeField] private Image dice;
    [SerializeField] private Sprite[] diceFaces;
    private int number;
    public void NumberMore(){
        if(number < 7) {
            number++;
            ChoseNumberText.text = number.ToString();
        }else{
            number = 1;
            ChoseNumberText.text = number.ToString();
        }
    }
    public void NumberLess(){
        if(number < 1) {
            number--;
            ChoseNumberText.text = number.ToString();
        }else{
            number = 6;
            ChoseNumberText.text = number.ToString();
        }
    }
    public void BetMore(){
        GetMoney(1);
    }
    public void BetLess(){
         GetMoney(-1);
    }
    public void Play(){
        if(valueBet != 0 && number != 0) {
            StartCoroutine(BetGame());
        }
    }
    void GetMoney(int money){
        if(playerValues.money != 0) {
            valueBet++;
            int totalIncrease =  money * 100;
            betText.text = string.Format("${0:0}", valueTextBet += totalIncrease); 
            StartCoroutine(moneyScript.TakeMoney(money));      
        }
    }
    IEnumerator BetGame(){
        int DiceNumber = Random.Range(0,6);
        int diceRotation = 0;
        while(diceRotation < 3){
            for(int i = 0; i < diceFaces.Length; i++) {
                dice.sprite = diceFaces[i];
                yield return new WaitForSeconds(0.25f);
            }
            diceRotation++;
        }
        dice.sprite = diceFaces[DiceNumber];
        if(DiceNumber == number) {
            StartCoroutine(Win());
        }else{
            StartCoroutine(Lose());
        }
    }
    IEnumerator Win(){
        int diceRotation = 0;
        StartCoroutine(moneyScript.GetSalary(valueBet)); 
        while(diceRotation < 3){
            dice.color = Color.green;
            yield return new WaitForSeconds(0.25f);
            dice.color = Color.white;
            diceRotation++;
        }    
        NighthChosesScript.BetSleep();
    }
    IEnumerator Lose(){
        int diceRotation = 0;
        while(diceRotation < 3){
            dice.color = Color.red;
            yield return new WaitForSeconds(0.25f);
            dice.color = Color.white;
            diceRotation++;
        }    
        NighthChosesScript.BetSleep();
    }
}
