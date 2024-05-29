using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
   [SerializeField] private  Animator animatorController;
    private bool isOpen;
    private bool isClosed;
    // Update is called once per frame
    void Start(){
        isOpen = false;
        isClosed = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Quest")){
            if(isClosed == false){
                isOpen = false;
                isClosed = true;
            }else if(isOpen == false){
                isClosed = false;
                isOpen = true;
            }
        }
        if(isClosed == true){
            animatorController.SetBool("canMovi", true);
        }
        if(isOpen == true){
            animatorController.SetBool("canMovi", false);
        }
    }
}
