using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private roadMap roadMapController;
    [SerializeField] private List<MensageController> mensageControllerScript;
    // Start is called before the first frame update
    void Awake()
    {
        ChangedDay();
        roadMapController.SpecialNight1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l")){
            DaySystem.day++;
            ChangedDay();
        }
    }
    void ChangedDay(){
        switch(DaySystem.day){
            case 1:
                roadMapController.InitializeWorkerTalkDay1();
                break;
            case 2:
                roadMapController.InitializeWorkerTalkDay2();
                break;
            case 3:
                roadMapController.InitializeWorkerTalkDay12();
                break;
            case 4:
                roadMapController.InitializeWorkerTalkDay20();
                break;
            case 5:
                roadMapController.InitializeWorkerTalkDay22();
                break;
            case 6:
                roadMapController.InitializeWorkerTalkDay25();
                break;
            case 7:
                roadMapController.InitializeWorkerTalkDay26();
                break;
            case 8:
                roadMapController.InitializeWorkerTalkDay27();
                break;
            default:
                break;
        }
        foreach (MensageController script in mensageControllerScript)
        {
            script.PickWorkerWords();
        }
        
    }
}
