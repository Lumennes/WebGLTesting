using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFPS : MonoBehaviour
{
    public Text text;
    public static float fps;
    public float updateTime = 1.0f;


    private void Start()
    {
        StartCoroutine(UpdateFPS());
    }

    IEnumerator UpdateFPS()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateTime);
            fps = 1.0f / Time.deltaTime;
            //GUILayout.Label("FPS: " + (int)fps);
            text.text = $"FPS: {(int)fps}";
        }
    }
}