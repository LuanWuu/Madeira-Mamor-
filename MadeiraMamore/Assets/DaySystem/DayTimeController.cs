using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private roadMap roadMapController;
    // Start is called before the first frame update
    void Awake()
    {
        ChangedDay();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ChangedDay(){
        switch(DaySystem.day){
            case 1:
                roadMapController.InitializeWorkerTalkDay1();
                break;
            case 2:
                roadMapController.InitializeWorkerTalkDay2();
                break;
            case 12:
                roadMapController.InitializeWorkerTalkDay12();
                break;
            case 20:
                roadMapController.InitializeWorkerTalkDay20();
                break;
            case 22:
                roadMapController.InitializeWorkerTalkDay22();
                break;
            case 25:
                roadMapController.InitializeWorkerTalkDay25();
                break;
            case 26:
                roadMapController.InitializeWorkerTalkDay26();
                break;
            case 27:
                roadMapController.InitializeWorkerTalkDay27();
                break;
        }
    }
}
