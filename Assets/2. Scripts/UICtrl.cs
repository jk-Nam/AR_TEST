using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICtrl : MonoBehaviour
{
    [SerializeField] private GameObject go_MainUI;
    [SerializeField] private GameObject go_TestUI;

    public bool isMain = true;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        isMain = true;
        go_MainUI.SetActive(true);
        go_TestUI.SetActive(false);
    }

    private void Update()
    {
        IsMain();
    }

    public void IsMain()
    {
       if (SceneManager.GetActiveScene().name == "Main")
        {
            isMain = true;
            go_MainUI.SetActive(true);
            go_TestUI.SetActive(false);
        }
       else
        {
            isMain = false;
            go_MainUI.SetActive(false);
            go_TestUI.SetActive(true);
        }
    }
}
