using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private RectTransform stamina;

    private float localMoveSpeed;
    private float localAcceleraWalk;
    private float localRunnigSpeed;
    private float localAcceleraRunnig;
    private Vector3 amoutStamina;

    private float localSpeed = 0;
    private bool isRuning;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SaveOrigin();
        float valueStamina = stamina.localScale.y / scriptTableValues.baseStamina;
        amoutStamina = new Vector3(0, valueStamina,0);
    }
    // Update is called once per frame
    void SaveOrigin(){
        localMoveSpeed = scriptTableValues.moveSpeed;
        localAcceleraWalk = scriptTableValues.acceleraWalk;
        localRunnigSpeed = scriptTableValues.runnigSpeed;
        localAcceleraRunnig = scriptTableValues.acceleraRunnig;
    }
    public void RestSpeed(){
        scriptTableValues.moveSpeed = localMoveSpeed;
        scriptTableValues.acceleraWalk = localAcceleraWalk;
        scriptTableValues.runnigSpeed = localRunnigSpeed;
        scriptTableValues.acceleraRunnig = localAcceleraRunnig;
    }
    private void FixedUpdate()
    {
        if(Input.GetAxis("RT") != 0 ||Input.GetKey(KeyCode.LeftShift) && stamina.localScale.y > 0.001f){
            isRuning = true;
        }else{
            isRuning = false;
        }
        if (Input.GetAxis("VerticalMoviJoystick") != 0 || Input.GetAxis("HorizontalMoviJoystick") != 0){
            MovePlayer(Input.GetAxis("HorizontalMoviJoystick"),  Input.GetAxis("VerticalMoviJoystick"));
        }else if(Input.GetAxis("KeyBoardH") != 0 || Input.GetAxis("KeyBoardY") != 0){
            MovePlayer(Input.GetAxis("KeyBoardH"), Input.GetAxis("KeyBoardY"));
        }else{
            rb.velocity = new Vector3(0,0,0);
            localSpeed = 0;
        }
    }
    void MovePlayer(float horizontal, float vertical){
        if(isRuning == true){
            AccelerationRunnig();
        }else{
            AccelerationWalk();  
        }
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * localSpeed  * Time.fixedDeltaTime;

        Vector3 localMovement = transform.TransformDirection(movement);

        rb.velocity = new Vector3(localMovement.x, rb.velocity.y, localMovement.z);
    }
    void AccelerationWalk(){
        if(localSpeed < scriptTableValues.moveSpeed){
            localSpeed += scriptTableValues.acceleraWalk;
        }else{
            localSpeed = scriptTableValues.moveSpeed;
        }
    }
    void AccelerationRunnig(){
        if(localSpeed < scriptTableValues.runnigSpeed){
            localSpeed += scriptTableValues.acceleraRunnig;
        }else{
            localSpeed = scriptTableValues.runnigSpeed;
        }
        stamina.localScale -= amoutStamina;
    }
}
