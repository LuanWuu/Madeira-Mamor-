using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerComponents", menuName = "PlayerValues")]
public class ScrpitTablePlayer : ScriptableObject
{
    [Header("Origin Player")]
    public float moveSpeed;
    public float acceleraWalk;
    public float runnigSpeed;
    public float acceleraRunnig;
    [Header("Stamina")]
    public float baseStamina;

}
