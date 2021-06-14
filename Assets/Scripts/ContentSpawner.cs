using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContentSpawner : MonoBehaviour
{
    public Data data;
 
    public GameObject contentPrefab;

    private ContentChanger _Changer;



    private void Start()
    {
        for (int i = 0; i < data.items.Count; i++)
        {
            Item item = data.items[i];
            GameObject _item = Instantiate(contentPrefab, transform, false);

            ContentContainer container = _item.GetComponent<ContentContainer>();

            container.AssignValue(item.title, item.description, item.image);

           // Button itemButton = _item.GetComponent<Button>();
            //itemButton.onClick.AddListener(delegate { _Changer.AssignValue(item.title, item.description, item.image); });
            //itemButton.onClick.AddListener(() => { _Changer.AssignValue(item.title, item.description, item.image); });
        }
    }
}
