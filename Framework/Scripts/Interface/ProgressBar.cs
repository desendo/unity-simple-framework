using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public RectTransform back;
    public RectTransform progress;
    public TMPro.TMP_Text digits;
    private float progressBarMinWidth = 0;
    private Image backImage;
    private Image progressImage;
    private Color progressImageColor;
    private Color backImageColor;
    private void Awake()
    {

        backImage = back.gameObject.GetComponent<Image>();
        backImageColor = backImage.color;
        progressImage = progress.gameObject.GetComponent<Image>();
        progressImageColor = progressImage.color;

        Init();
    }
    void Init()
    {
        progressBarMinWidth = -back.sizeDelta.x;
        SetProgress(0);

    }
    private float _pr;
    /// <summary>
    /// 0..1
    /// </summary>
    /// <param name="pr"></param>
    public void SetProgress(float pr)
    {
        pr = Mathf.Clamp01(pr);
        //Debug.Log(pr);

        _pr = pr;
       progress.offsetMax = new Vector2(progressBarMinWidth * (1-pr), progress.offsetMax.y);
        digits.text = (pr * 100).ToString() + "/" + "100";
    }
    public void SetProgress(float currentValue, float maxValue, float minValue=0)
    {
        currentValue = Mathf.Clamp(currentValue,minValue,maxValue);

        _pr = (currentValue) / (maxValue - minValue);
        progress.offsetMax = new Vector2(progressBarMinWidth * (1 - (currentValue)/(maxValue-minValue)), progress.offsetMax.y);
        digits.text = ((int)currentValue).ToString() + "/" + ((int)maxValue).ToString();
    }
    public void Disable()
    {
        
    }
    float p = 0;
    void Update()
    {
        p += Time.deltaTime;
        SetProgress(p, 300);
    }
}
