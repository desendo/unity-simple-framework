using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "GameParameters.asset", menuName = "GameParameters", order = 1)]
public class GameParameters : ScriptableObject
{
    [Header("Game Params")]
    public float MassFactor = 1000;
    public float StandartGravity = 10;
    public float G = 1;
    public float FrameRate;

    public float ForceFactor;



}