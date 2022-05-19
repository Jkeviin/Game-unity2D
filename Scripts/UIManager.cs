using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class UIManager : MonoBehaviour
{

    public AudioSource clip;

    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }


    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }
    
    public void AnotherOptions()
    {
        //Sounds
        //Graphics
    }

      public void GoMainMenu()
    {
        Return();
        SceneManager.LoadScene("MainMenu");
    }

    public void Again()
    {
        Return();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void PlaySoundButoon()
    {
        clip.Play();
    }
}
