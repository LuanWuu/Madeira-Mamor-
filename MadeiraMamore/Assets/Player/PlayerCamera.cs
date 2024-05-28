using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer scriptTableValues;

    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform playerBody;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Transform cheif;
    [SerializeField] private Transform EyesBaltasar;
    [SerializeField] private Transform Baltasar;

    [SerializeField] private OptionsValue optionsScriptable;
 
    private float sensitivityX = 1.0f;
    private float sensitivityY = 1.0f;

    private float controlSensitivityX = 1.0f;
    private float controlSensitivityY = 1.0f;

    private float cursorSize = 1.0f;
    [System.NonSerialized] public Color  cursorColor;

    private float rotateX;
    private float rotateY;

    private float angleYmim = -90;
    private float angleYmax = 90;

    private float smoothX;
    private float smoothY;

    private float coefSmoothX = 0.005f;
    private float coefSmoothY = 0.005f;

    void Start()
    {
        scriptTableValues.dontFineshed = false;
        scriptTableValues.canMoviCamera = true;
        scriptTableValues.DisabledCursor();
    }

    private void LateUpdate() 
    {
        transform.position = playerHead.position; // posicao da camera para cabeca do player

    }
    void Update(){
        if(scriptTableValues.canMoviCamera == true){
            if (Input.GetJoystickNames().Length > 0){
                float horizontalDeltaJoystick = Input.GetAxis("HorizontalCameraJoystick") * controlSensitivityX;// Valor de Eixo X
                float verticalDeltaJoystick = Input.GetAxis("VerticalCameraJoystick") * controlSensitivityY; // Valor de Eixo Y
                if(horizontalDeltaJoystick != 0 || verticalDeltaJoystick != 0){
                    MoveCamera(horizontalDeltaJoystick, verticalDeltaJoystick);
                }
            }
            float horizontalDeltaMouse = Input.GetAxisRaw("Mouse X") * sensitivityX;// Valor de Eixo X
            float verticalDeltaMouse = Input.GetAxisRaw("Mouse Y") * sensitivityY; // Valor de Eixo Y
            if(horizontalDeltaMouse != 0 || verticalDeltaMouse != 0){
                MoveCamera(horizontalDeltaMouse, verticalDeltaMouse);
            }
        }
        if(scriptTableValues.dontFineshed == true) {
            transform.LookAt(EyesBaltasar);
            playerBody.LookAt(Baltasar);  
            scriptTableValues.canMoviCamera = false;
        }
        sensitivityX = optionsScriptable.sensitX ;
        sensitivityY = optionsScriptable.sensitY ;
        controlSensitivityX = optionsScriptable.controlSensitX;
        controlSensitivityY = optionsScriptable.controlSensitY;
        cursorSize = optionsScriptable.cursorSize;
        CursorCustomize();
    }
    void CursorCustomize(){
        cursor.transform.localScale = new Vector3(cursorSize, cursorSize, cursorSize);
    }
    void MoveCamera(float horizontal, float vertical){

        smoothX = Mathf.Lerp(smoothX, horizontal,coefSmoothX);// deixando suave as mudancas do eixo x
        smoothY = Mathf.Lerp(smoothY, vertical, coefSmoothY);// deixando suave as mudancas do eixo y

        rotateX += horizontal;// somando horizontal
        rotateY += vertical;// somando Vetivcal

        rotateY = Mathf.Clamp(rotateY, angleYmim, angleYmax); // limitando o Eixo Y

        playerBody.localEulerAngles = new Vector3(0,rotateX,0); // Rotacionado o Player
        transform.localEulerAngles = new Vector3(-rotateY,rotateX,0); // rotacionando a Camera  
    }
}
