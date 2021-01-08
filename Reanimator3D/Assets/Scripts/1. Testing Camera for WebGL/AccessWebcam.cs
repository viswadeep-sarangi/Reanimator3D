using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessWebcam : MonoBehaviour
{
    public RawImage webcamRawImage;
    public TextMeshProUGUI Msgs;

    private WebCamTexture webCamTexture;
    // Start is called before the first frame update
    void Start()
    {
        Msgs.text = "Starting please wait...";

        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Msgs.text = "No cameras found!";
            return;
        }

        webCamTexture = new WebCamTexture(devices[0].name);
        webcamRawImage.texture = webCamTexture;
        webCamTexture.Play();

        Msgs.text = "Playing webcam texture now...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
