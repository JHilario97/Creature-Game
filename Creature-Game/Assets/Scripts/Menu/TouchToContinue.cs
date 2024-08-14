using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class TouchToContinue : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        //SceneManager.LoadScene("NextSceneName");
    }
}
