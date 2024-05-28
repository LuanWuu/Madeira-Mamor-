using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManegerOptions : MonoBehaviour
{

    [SerializeField] private GameObject keyboardOptions;
    [SerializeField] private GameObject mouseOptions;
    [SerializeField] private GameObject controlOptions;
    [SerializeField] private GameObject soundOptions;

    [Header("Slider Mouse Sensitivity")]
    [SerializeField] private Slider sensitivityX;
    [SerializeField] private Slider sensitivityY;

    private float valueSensitX;
    private float valueSensitY;

    [Header("Slider Control Sensitivity")]
    [SerializeField] private Slider controlSensitivityX;
    [SerializeField] private Slider controlSensitivityY;

    private float valueControlSensitX;
    private float valueControlSensitY;

    
    [Header("Ponter Size")]
    [SerializeField] private Slider cursorSize;

    private float valueCursorSize;

    [SerializeField] private OptionsValue optionsScriptable;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        valueSensitX = sensitivityX.value;
        valueSensitY = sensitivityY.value;
        valueControlSensitX = controlSensitivityX.value;
        valueControlSensitY = controlSensitivityY.value;
        valueCursorSize = cursorSize.value;
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

    public void ApplyConfig(){
        //Debug.Log(scriptPlayerCamera.gameObject.name);
        //Debug.Log(scriptMoviPlayer.gameObject.name);
        optionsScriptable.sensitX = valueSensitX;
        optionsScriptable.sensitY = valueSensitY;
        optionsScriptable.controlSensitX = valueControlSensitX;
        optionsScriptable.controlSensitY = valueControlSensitY;
        optionsScriptable.cursorSize = valueCursorSize;
    }
}
