using UnityEngine;
using System.Collections;
using System;

public class SetupSubCam : MonoBehaviour
{
    public Camera _camera;
    private void Awake()
    {
        float aspect = (float)Screen.height / (float)Screen.width; // Portrait
                                                     //aspect = (float)Screen.width / (float)Screen.height; // Landscape
        Debug.Log("Aspect Ratio:" + aspect);
        if (aspect >= 1.74)  // 16:9
        {
            _camera.orthographicSize = 9.6f;
            Debug.Log("16:9");
        }
        else if (aspect > 1.61)// 5:3
            _camera.orthographicSize = 9.12f;
        else if (Math.Abs(aspect - 1.6) < Mathf.Epsilon)// 16:10
            _camera.orthographicSize = 8.7f;
        else if (aspect >= 1.5)// 3:2
            _camera.orthographicSize = 8.20f;
        else
        { // 4:3
            _camera.orthographicSize = 7.26f;
        }
    }
}
