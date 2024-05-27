using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private RectTransform stamina;
    
    private float localMoveSpeed;
    private float localAcceleraWalk;
    private Vector3 amoutStamina;

    private float localSpeed = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        scriptTableValues.canMovi = true;
        rb = GetComponent<Rigidbody>();
        SaveOrigin();
    }
    // Update is called once per frame
    void SaveOrigin(){
        localMoveSpeed = scriptTableValues.moveSpeed;
        localAcceleraWalk = scriptTableValues.acceleraWalk;
    }
    public void RestSpeed(){
        scriptTableValues.moveSpeed = localMoveSpeed;
        scriptTableValues.acceleraWalk = localAcceleraWalk;
    }
    private void FixedUpdate()
    {
        if(scriptTableValues.canMovi == true){
            if (Input.GetJoystickNames().Length > 0){
                if (Input.GetAxis("VerticalMoviJoystick") != 0 || Input.GetAxis("HorizontalMoviJoystick") != 0){
                    MovePlayer(Input.GetAxis("HorizontalMoviJoystick"),  Input.GetAxis("VerticalMoviJoystick"));
                }else{
                    rb.velocity = new Vector3(0,0,0);
                    localSpeed = 0;
                }
            }else if(Input.GetAxis("KeyBoardH") != 0 || Input.GetAxis("KeyBoardY") != 0){
                MovePlayer(Input.GetAxis("KeyBoardH"), Input.GetAxis("KeyBoardY"));
            }else{
                rb.velocity = new Vector3(0,0,0);
                localSpeed = 0;
            }
        }
    }
    void MovePlayer(float horizontal, float vertical){
        AccelerationWalk();  
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

}
