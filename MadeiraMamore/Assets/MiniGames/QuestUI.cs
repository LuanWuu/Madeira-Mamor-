using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject questInterface;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m")){
            if(isOpen == false){
                isOpen = true;
                questInterface.SetActive(false);
            }else{
                isOpen = false;
                questInterface.SetActive(true);
            }
        }
        
    }
}
