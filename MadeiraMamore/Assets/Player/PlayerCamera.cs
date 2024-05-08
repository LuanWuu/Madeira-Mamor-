using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    private static bool canMoviCamera;

    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform playerBody;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Transform cheif;

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
    }

    private void LateUpdate() 
    {
        transform.position = playerHead.position; // posicao da camera para cabeca do player

    }
    void Update(){
        if(canMoviCamera == true){
            Mouse();
            JoyStick();
        }
        sensitivityX = optionsScriptable.sensitX ;
        sensitivityY = optionsScriptable.sensitY ;
        controlSensitivityX = optionsScriptable.controlSensitX;
        controlSensitivityY = optionsScriptable.controlSensitY;
        cursorSize = optionsScriptable.cursorSize;
        CursorCustomize();
    }
    public static void EnabledCursor(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canMoviCamera = false;
    }
    public static void DisabledCursor(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMoviCamera = true;
    }
    void CursorCustomize(){
        cursor.transform.localScale = new Vector3(cursorSize, cursorSize, cursorSize);
    }
    void Mouse(){
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;// Valor de Eixo X
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY; // Valor de Eixo Y

        smoothX = Mathf.Lerp(smoothX,horizontalDelta,coefSmoothX);// deixando suave as mudancas do eixo x
        smoothY = Mathf.Lerp(smoothY, verticalDelta, coefSmoothY);// deixando suave as mudancas do eixo y

        rotateX += horizontalDelta;// somando horizontal
        rotateY += verticalDelta;// omando Vetivcal

        rotateY = Mathf.Clamp(rotateY, angleYmim, angleYmax); // limitando o Eixo Y

        playerBody.localEulerAngles = new Vector3(0,rotateX,0); // Rotacionado o Player
        transform.localEulerAngles = new Vector3(-rotateY,rotateX,0); // rotacionando a Camera
    }

    void JoyStick(){
        float horizontalDelta = Input.GetAxis("HorizontalCameraJoystick") * controlSensitivityX;// Valor de Eixo X
        float verticalDelta = Input.GetAxis("VerticalCameraJoystick") * controlSensitivityY; // Valor de Eixo Y

        smoothX = Mathf.Lerp(smoothX,horizontalDelta,coefSmoothX);// deixando suave as mudancas do eixo x
        smoothY = Mathf.Lerp(smoothY, verticalDelta, coefSmoothY);// deixando suave as mudancas do eixo y

        rotateX += horizontalDelta;// somando horizontal
        rotateY += verticalDelta;// omando Vetivcal

        rotateY = Mathf.Clamp(rotateY, angleYmim, angleYmax); // limitando o Eixo Y

        playerBody.localEulerAngles = new Vector3(0,rotateX,0); // Rotacionado o Player
        transform.localEulerAngles = new Vector3(-rotateY,rotateX,0); // rotacionando a Camera
    }
}
