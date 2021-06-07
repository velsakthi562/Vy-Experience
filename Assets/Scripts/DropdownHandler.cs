using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownHandler : MonoBehaviour
{


    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            SceneManager.LoadScene("VyExperience Ui");
        }
        if(val == 1)
        {
            SceneManager.LoadScene("ARDemo");
        }
        if(val == 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if(val == 3)
        {
            SceneManager.LoadScene("ARDemo 1");
        }
        if (val == 4)
        {
            SceneManager.LoadScene("ARDemo 2");
        }
    }

  

  
}
