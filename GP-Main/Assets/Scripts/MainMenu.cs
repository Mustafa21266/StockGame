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
        // start button to start the game as it will load the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame ()
    {
        // quit button as it will close the game 
        Debug.Log("Quit");
        // UnityEditor.EditorApplication.isPlaying = UnityEditor.EditorApplication.isPlaying ? false : UnityEditor.EditorApplication.isPlaying;
        Application.Quit();
    }

    public void OpenUserAccount()
    {
        // opening user account panel
        this.userAccountPanel.SetActive(true);
    }
}
