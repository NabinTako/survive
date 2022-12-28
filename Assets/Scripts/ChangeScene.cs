using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeScene(string level)
    {
        if(level == "Easy")
        {
            SceneManager.LoadScene("easy");
        }else if(level == "Medium")
        {
            SceneManager.LoadScene("medium");
        }
        else
        {
            SceneManager.LoadScene("hard");
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
