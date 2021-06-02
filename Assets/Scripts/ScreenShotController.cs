using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotController : MonoBehaviour
{
    int width;
    int height;

    private Camera _camera;

    bool takeScreenShot = false;

    [SerializeField]
    private GameObject takingScreenShot;

    [SerializeField]
    private GameObject previewScreen;

    [SerializeField]
    private RawImage previewImage;

    private Texture2D screenshot;
    private byte[] bytes;
    

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        width = Screen.width;
        height = Screen.height;
    }

    public void TakeScreenShot()
    {
        if (takeScreenShot)
        {
            return;
        }

        takeScreenShot = true;
        StartCoroutine(TakePic());
    }

    private IEnumerator TakePic()
    {
        takingScreenShot.SetActive(true);

        RenderTexture rt = new RenderTexture(width, height, 24);
        _camera.targetTexture = rt;

        screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
        _camera.Render();

        RenderTexture.active = rt;

        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);

        _camera.targetTexture = null;
        RenderTexture.active = null;

        Destroy(rt);

        bytes = screenshot.EncodeToPNG();

        File.WriteAllBytes(Application.persistentDataPath + "/screenshot.png", bytes);

        Debug.Log(string.Format("Take screenshot to: {0}", Application.persistentDataPath + "/screenshot.png"));

        yield return new WaitForSeconds(1f);

        screenshot.LoadImage(bytes);
        previewImage.texture = screenshot;

        takingScreenShot.SetActive(false);
        previewScreen.SetActive(true);

        takeScreenShot = false;
    }

    public void SaveImage()
    {
        string dir = Application.persistentDataPath + "/Pics";

        Debug.Log("File Path: " + dir);

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string[] files = Directory.GetFiles(dir);

        string filename = "/pic" + (files.Length + 1) + ".png";

        bytes = screenshot.EncodeToPNG();

        File.WriteAllBytes(dir + filename, bytes);

        Debug.Log(string.Format("Take screenshot to: {0}", dir + filename));

        previewImage.texture = null;
        previewScreen.SetActive(false);
    }
}