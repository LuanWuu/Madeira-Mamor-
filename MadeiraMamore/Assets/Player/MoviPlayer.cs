using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        Keyboard();
    

        string[] joysticksController = Input.GetJoystickNames();

        // Verifique se há controle conectado
        if (joysticksController.Length > 0 && !string.IsNullOrEmpty(joysticksController[0]))
        {
            JoyStick();
        }
    }
    private void Keyboard()
    {
        float horizontalInput = Input.GetAxis("KeyBoardH");
        float verticalInput = Input.GetAxis("KeyBoardY");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            //Debug.Log("teste");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
            Vector3 localMovement = transform.TransformDirection(movement);
            rb.velocity = new Vector3(localMovement.x, rb.velocity.y, localMovement.z);
        }

    }
    private void JoyStick()
    {

        float horizontalInput = Input.GetAxis("HorizontalMoviJoystick");
        float verticalInput = Input.GetAxis("VerticalMoviJoystick");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            //Debug.Log("horizintal " + horizontalInput);
            //Debug.Log("vertical" + verticalInput);
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
            Vector3 localMovement = transform.TransformDirection(movement);
            rb.velocity =  rb.velocity = new Vector3(localMovement.x, rb.velocity.y, localMovement.z);
        }

    }
}
