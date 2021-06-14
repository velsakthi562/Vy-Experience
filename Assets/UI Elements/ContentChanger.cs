using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContentChanger : MonoBehaviour
{
   

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI descrption;
    [SerializeField] Image image;

    public void AssignValue(string _title, string _value, Sprite _image)
    {
        title.text = _title;
        descrption.text = _value;
        image.sprite = _image;
    }
}

