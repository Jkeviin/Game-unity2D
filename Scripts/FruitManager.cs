using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour   
{
    public Text levelCleared;

    public GameObject transition;

    public Text totalFruits;
    public Text fruitsCollected;

    private int totalFroitsInLevel;


    private void Start()
    {
        totalFroitsInLevel = transform.childCount;
    }
    private void FixedUpdate()
    {
        AllFruitCollected();
        totalFruits.text = totalFroitsInLevel.ToString();
        int cantidadEnNumero = totalFroitsInLevel - (transform.childCount);
        fruitsCollected.text = cantidadEnNumero.ToString();
    }
    public void AllFruitCollected()
    {
        if(transform.childCount == 0)
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
