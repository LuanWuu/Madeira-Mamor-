using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegerOptions : MonoBehaviour
{

    [SerializeField] private GameObject keyboardOptions;
    [SerializeField] private GameObject mouseOptions;
    [SerializeField] private GameObject controlOptions;
    [SerializeField] private GameObject soundOptions;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       for(int i = 0; i < 19; i++) {
            if(Input.GetKeyDown("joystick button " + i.ToString())) {
                Debug.Log("joystick button " + i.ToString());
            }
       }

    }

    public void KeyBoard(){
        keyboardOptions.SetActive(true);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(false);
        soundOptions.SetActive(false);
    }
    public void Mouse () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(true);
        controlOptions.SetActive(false);
        soundOptions.SetActive(false);
    }
    public void Control () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(true);
        soundOptions.SetActive(false);
    }
    public void  Sound () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(false);
        soundOptions.SetActive(true);
    }
}
