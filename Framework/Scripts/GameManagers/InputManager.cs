using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    const string VERTICAL = "Vertical";
    const string HORIZONTAL = "Horizontal";
    const string ROTATE = "Rotate";

    public event System.Action<float> MainAxis = delegate { };
    public event System.Action<float> RotateAxis = delegate { };
    public event System.Action<float> SideAxis = delegate { };

    
    private void OnEnable()
    {

        Manager.game.OnStateSwithed += ResetHandlers;
    }
    private void OnDisable()
    {
        Manager.game.OnStateSwithed -= ResetHandlers;
    }


    void Update()
    {


    }
    void HandleFlightKeys()
    {
        MainAxis.Invoke(Input.GetAxis(VERTICAL));
        SideAxis.Invoke(Input.GetAxis(HORIZONTAL));
        RotateAxis.Invoke(Input.GetAxis(ROTATE));

    }
    void ResetHandlers()
    {
        MainAxis.Invoke(0);
        RotateAxis.Invoke(0);
        SideAxis.Invoke(0);

    }
}
