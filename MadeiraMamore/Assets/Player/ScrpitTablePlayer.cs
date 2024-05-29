using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerComponents", menuName = "PlayerValues")]
public class ScrpitTablePlayer : ScriptableObject
{
    [Header("Origin Player")]
    public bool canMovi = true;
    public float moveSpeed;
    public float acceleraWalk;
    [Header("Money")]
    public int money;
    [Header("Camera")]
    public bool dontFineshed = false;
    public bool canMoviCamera = true;
    [Header("stamina")]
    public int staminaRecuperNight;
    [Header("Food Menu")]
    public bool canOpenFoodMenu;
    [Header("Salary")]
    public int salary;

    public void EnabledCursor(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canMoviCamera = false;
    }
    public void DisabledCursor(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMoviCamera = true;
    }
}
