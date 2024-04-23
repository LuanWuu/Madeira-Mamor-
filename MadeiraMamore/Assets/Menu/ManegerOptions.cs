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

    [System.NonSerialized] public float valueSensitX;
    [System.NonSerialized] public float valueSensitY;

    [Header("Slider Control Sensitivity")]
    [SerializeField] private Slider controlSensitivityX;
    [SerializeField] private Slider controlSensitivityY;

    [System.NonSerialized] public float valueControlSensitX;
    [System.NonSerialized] public float valueControlSensitY;

    
    [Header("Ponter Size")]
    [SerializeField] private Slider cursorSize;

    [System.NonSerialized] public float valueCursorSize;

    private PlayerCamera scriptPlayerCamera;
    private MoviPlayer scriptMoviPlayer;
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

    public void FindPlayer(){
        scriptPlayerCamera = GameObject.FindWithTag("MainCamera").GetComponent<PlayerCamera>();
        scriptMoviPlayer = GameObject.FindWithTag("player").GetComponent<MoviPlayer>();
        ApplyConfig();
    }
    public void ApplyConfig(){
        if(SceneManager.GetActiveScene().buildIndex != 0){
        //Debug.Log(scriptPlayerCamera.gameObject.name);
        //Debug.Log(scriptMoviPlayer.gameObject.name);
        scriptPlayerCamera.sensitivityX = valueSensitX;
        scriptPlayerCamera.sensitivityY = valueSensitY;
        scriptPlayerCamera.controlSensitivityX = valueControlSensitX;
        scriptPlayerCamera.controlSensitivityY = valueControlSensitY;

        scriptPlayerCamera.cursorSize = valueCursorSize;
         scriptPlayerCamera.CursorCustomize();
        }
    }
}
