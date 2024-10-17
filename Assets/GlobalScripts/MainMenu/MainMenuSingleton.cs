using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSingleton : MonoBehaviour
{
    [SerializeField] private GameObject _exitButton;

    void Awake(){
#if UNITY_WEBGL

        _exitButton.SetActive(false);

#else

        _exitButton.SetActive(true);

#endif
    }

    public void StartGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void CloseGame(){
        Application.Quit();
    }
}
