using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaffleQuest : MonoBehaviour
{
    [Header("Mangers dos minigames")]
    [SerializeField] private GameObject carry;
    [Header("Timer")]
    [SerializeField] private GameObject timer;
    [Header("Timer of Carry Minigame")]
    [SerializeField] private float carryTime;
    [Header("Total Points of time")]
    [SerializeField] private float pointTimeQuest;
    [Header("Nivelamento")]
    [SerializeField] private float goodScore;
    [SerializeField] private float normalScore;
    [Header("Roteiro")]
    [SerializeField] private roadMap roadMapScriptable;

    private Timer timerScript;
    private int numberMinigame;
    private int beforeNumberMinigame;
    private float timeMinigame = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerScript = timer.GetComponent<Timer>();
        Debug.Log("teste " + timerScript.gameObject.name);
        DecideQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v")){
            CompleteQuest();
        }
    }
    public void CompleteQuest(){
        timerScript.stop = true;
        float score = (timerScript.timerleft * pointTimeQuest)/timeMinigame;
        Debug.Log("Complete" +  score);
        if(score > goodScore){
            roadMapScriptable.GoodWork();
            Debug.Log("Complete" +  score);
        }else if(score > normalScore){
            roadMapScriptable.MediumWork();
            Debug.Log("Complete" +  score);
        }else{
            roadMapScriptable.BadWork();
            Debug.Log("Complete" +  score);
        }
        Invoke("Reset", 0.5f);
    }
    public void EndTime(){
        Debug.Log("time is over");
        Invoke("Reset", 0.5f);
    }
    void Reset(){
        //SceneManager.LoadScene("SecondArea");
    }
    void DecideQuest(){
 
        carry.SetActive(true);
        timeMinigame = carryTime;
        timer.SetActive(true);
        timerScript.timerleft = timeMinigame;
        timerScript.stop = false;
        timerScript.end = false;
    }
    
}
