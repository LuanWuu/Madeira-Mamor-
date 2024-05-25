using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerComponents", menuName = "PlayerValues")]
public class ScrpitTablePlayer : ScriptableObject
{
    [Header("Origin Player")]
    public bool canMovi = true;
    public bool canMoviCamera = true;
    public float moveSpeed;
    public float acceleraWalk;
    public float runnigSpeed;
    public float acceleraRunnig;
    [Header("Stamina")]
    public float baseStamina;
    [Header("Money")]
    public int money;

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
