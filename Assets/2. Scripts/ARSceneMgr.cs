using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARSceneMgr : MonoBehaviour
{
    private ARPlaceOnPlane theARPlaceOnPlane;

    private void Start()
    {
        theARPlaceOnPlane = FindObjectOfType<ARPlaceOnPlane>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
