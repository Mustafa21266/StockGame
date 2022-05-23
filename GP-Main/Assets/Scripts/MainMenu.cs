using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity;
using UnityEditor;
public class MainMenu : MonoBehaviour
{
    public GameObject userAccountPanel; 
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        EditorApplication.isPlaying = EditorApplication.isPlaying ? false : EditorApplication.isPlaying;
        Application.Quit();
    }

    public void OpenUserAccount()
    {
        this.userAccountPanel.SetActive(true);
    }
}
