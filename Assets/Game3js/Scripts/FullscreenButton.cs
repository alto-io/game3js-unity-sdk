using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
 
public class FullscreenButton : Button {
    private int originalWidth;
    private int originalHeight;

    override protected void Start()
    {
        originalWidth = Screen.width;
        originalHeight = Screen.height;
    }

    public override void OnPointerDown(PointerEventData eventData) {
        bool wasFullScreen = Screen.fullScreen;
        Screen.fullScreen = !wasFullScreen;

        int width = Screen.fullScreen ? Display.main.systemWidth : originalWidth;
        int height = Screen.fullScreen ? Display.main.systemHeight : originalHeight;

        Screen.SetResolution(width, height, !wasFullScreen);

         Debug.Log(this.gameObject.name + " Was Clicked.");
    }
}
