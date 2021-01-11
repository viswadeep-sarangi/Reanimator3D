using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessWebcam : MonoBehaviour
{
    public RawImage webcamRawImage;
    public TextMeshProUGUI Msgs;
    public GameObject DebugTextPanel;
    public TextMeshProUGUI DebugText;

    private float webcamAspectRatio;
    private WebCamTexture webCamTexture;
    // Start is called before the first frame update
    void Start()
    {
        ShowText("Starting please wait...");

        webcamAspectRatio = -1;
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            ShowText("No cameras found!");            
            return;
        }

        webCamTexture = new WebCamTexture(devices[0].name);
        webcamRawImage.texture = webCamTexture;
        webCamTexture.Play();
        ShowText("Started playing webcam texture now...");

        CloseDebugText();
    }

    private void ShowText(string s)
    {
        Msgs.text = s;
        DebugText.text += "\n" + s;
    }

    public void CloseDebugText()
    {
        DebugTextPanel.SetActive(false);
    }
    public void ShowDebugText()
    {
        DebugTextPanel.SetActive(true);
    }

    private void Update()
    {
        if(webcamAspectRatio < 0 && webCamTexture !=null && webCamTexture.didUpdateThisFrame)
        {
            var arf = webcamRawImage.gameObject.GetComponent<AspectRatioFitter>();
            //arf.aspectMode = AspectRatioFitter.AspectMode.FitInParent;
            webcamAspectRatio = webCamTexture.width * 1.0f / webCamTexture.height;
            arf.aspectRatio = webcamAspectRatio;
            ShowText(string.Format("Webcam width={0}, height={1}, aspect ratio={2}", webCamTexture.width, webCamTexture.height, arf.aspectRatio));
            ShowText("Playing webcam texture now...");
        }
    }

}
