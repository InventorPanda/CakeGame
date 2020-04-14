using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    public string sceneName;

    public void SceneChange()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
