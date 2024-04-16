using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaffleQuest : MonoBehaviour
{
    [Header("nomes das quest")]
    [SerializeField] private string[] minigame;
    [Header("Mangers dos minigames")]
    [SerializeField] private GameObject carry;

    private int numberMinigame;
    private int beforeNumberMinigame;
    // Start is called before the first frame update
    void Start()
    {
        DecideQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v")){
            DecideQuest();
        }
    }
    void DecideQuest(){
        //while (true){
        //    numberMinigame = Random.Range(0, minigame.Length);
        //    if (numberMinigame != beforeNumberMinigame){
        //        Debug.Log("minigame: " + numberMinigame);
        //        break;
        //    }
        //}
        numberMinigame = 0;
        switch(numberMinigame){
            case 0:
                carry.SetActive(true);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
        beforeNumberMinigame = numberMinigame;
    }
    
}
