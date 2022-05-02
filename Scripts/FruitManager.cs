using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour   
{
    public Text levelCleared;
    public GameObject transition;
    public void AllFruitCollected()
    {
        if(transform.childCount == 1)
        {
            levelCleared.gameObject.SetActive(true);
            Invoke("transitionActive", 1);
        }
    }

    void ChangeEscene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void transitionActive()
    {
        Invoke("ChangeEscene", 0.8f);
        levelCleared.gameObject.SetActive(false);
        transition.SetActive(true);
    }
}
