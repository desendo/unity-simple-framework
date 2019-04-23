using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public static InfoManager current;
    private void Awake()
    {
        if (current == null)
            current = this;
    }
    public TMP_Text velocity;
    public TMP_Text accel;
    
    public TMP_Text altitude;
    public TMP_Text mass;
    public TMP_Text fuel;
    public TMP_Text density;
    public ProgressBar thrust;
    public TMP_Text airForce;
}
