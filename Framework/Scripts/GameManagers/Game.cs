using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    None, Menu, Play
}
public class Game : MonoBehaviour
{

    
    public event Action OnStateSwithed = delegate { };
    GameState state;
    public GameState State { get => state; private set => state = value; }

    public void SetState(GameState state)
    {
        State = state;
        //OnStateSwithed();

    }



    internal bool IsMenu()
    {
        return State == GameState.Menu;
    }
}
