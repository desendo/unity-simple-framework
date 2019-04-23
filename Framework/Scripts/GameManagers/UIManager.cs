using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SoundManager))]
public class UIManager : MonoBehaviour
{
    SoundManager soundManager;



    [SerializeField]
    List<TextItem> textItemsList;
    [SerializeField] RectTransform panel=null;
    [SerializeField] RectTransform labelPrefab=null;
    [SerializeField] float labelYStep=20;
    Dictionary<string, TextItem> textItems;

    private void Awake()
    {
        textItemsList = new List<TextItem>();

        soundManager = gameObject.GetComponent<SoundManager>();
        InitLabels();

    }

    #region Labels

    public void SetLabelValue(string key, int val)
    {
        string stringValue = val.ToString();
        SetStringedValue(key, stringValue);
    }
    public void SetLabelValue(string key, string val)
    {
        SetStringedValue(key, val);
    }
    public void SetLabelValue(string key, float val)
    {
        string stringValue = val.ToString();

        SetStringedValue(key, stringValue);
    }
    private void SetStringedValue(string key, string stringValue)
    {
           TextItem textItem;
        if (!textItems.ContainsKey(key))
        {
            textItem = new TextItem();
            textItem.itemName = key;
            RectTransform label = Instantiate(labelPrefab, panel);
            label.name = key;
            label.anchoredPosition = new Vector2(label.anchoredPosition.x, -labelYStep * textItemsList.Count);
            textItem.item = label.GetComponent<TMP_Text>();
            textItemsList.Add(textItem);
            textItems.Add(key, textItem);
        }

        if (textItems.TryGetValue(key, out textItem))
        {
            textItem.SetValue(stringValue);
        }

        panel.sizeDelta = new Vector2(panel.sizeDelta.x, labelYStep * textItemsList.Count+10);
    }

    private void InitLabels()
    {
        textItems = new Dictionary<string, TextItem>();

        if (textItemsList != null && textItemsList.Count > 0)
        {
            int i = 0;
            foreach (TextItem textItem in textItemsList)
            {
                if (!textItems.ContainsKey(textItem.itemName))
                {
                    textItems.Add(textItem.itemName, textItem);
                }
                else if (!textItems.ContainsValue(textItem))
                {
                    textItems.Add(textItem.itemName + "_" + i.ToString(), textItem);
                    i++;
                }
            }
        }
    }
    #endregion

    public void PlayClick()
    {
        soundManager.Play("click");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class TextItem
{
    public string itemName;
    public TMP_Text item;

    public void SetValue(string value)
    {

        item.text = string.Concat(itemName, ": ", value);
    }
    public void ResetValue()
    {

        item.text = string.Concat(itemName, ": ");
    }
}