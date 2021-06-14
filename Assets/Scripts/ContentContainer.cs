using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ContentContainer : MonoBehaviour
{
    private string _title;
    public string title
    {
        get { return _title; }
        set {_title = value; }
    }



    private string _description;
    public string description
    {
        get { return _description; }
        set { _description = value; }
    }



    private Sprite _sprite;
    public Sprite image
    {
        get { return _sprite; }
        set { _sprite = value; }
    }



    public TextMeshProUGUI Title;
    public Image sprite;
    public TextMeshProUGUI Description;

    
    public void AssignValue(string sentTitle, string sentDescription, Sprite sentImage)
    {
        _title = sentTitle;
        _description = sentDescription;
        _sprite = sentImage;

        Title.text = _title;
        Description.text = _description;
        sprite.sprite = _sprite;
    }
}
