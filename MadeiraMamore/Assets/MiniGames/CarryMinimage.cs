using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryMinimage : MonoBehaviour
{
    [SerializeField] private GameObject nineBox;
    [SerializeField] private GameObject twelveBox;
    [SerializeField] private GameObject fifteenBox;
    [SerializeField] private Transform boxsPosition;
    [SerializeField] private int optionsBox;

    private int numberMinigame;
    private int beforeNumberMinigame;
    // Start is called before the first frame update
    void Start()
    {
        DecideAmoutBox();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DecideAmoutBox(){
        while (true){
            numberMinigame = Random.Range(0, optionsBox);
            if (numberMinigame != beforeNumberMinigame){
                Debug.Log("minigame: " + numberMinigame);
                break;
            }
        }
        numberMinigame = 0;
        switch(numberMinigame){
            case 0:
                Instantiate(nineBox, boxsPosition.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(twelveBox, boxsPosition.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(fifteenBox, boxsPosition.position, Quaternion.identity);
                break;
            default:
                break;
        }
        beforeNumberMinigame = numberMinigame;
    }
}
