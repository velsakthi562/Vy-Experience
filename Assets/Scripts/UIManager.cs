using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, contentMenu, viewMenu;


    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(-1145, 0), 0.50f);
        contentMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void BackMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        contentMenu.DOAnchorPos(new Vector2(1145, 0), 0.25f);
    }
}
