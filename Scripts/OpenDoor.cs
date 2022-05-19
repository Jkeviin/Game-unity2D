using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text KeyPress;
    private bool inDoor = false;
    public GameObject transition;
    public Canvas canvas;
    public string LevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeyPress.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        KeyPress.gameObject.SetActive(false);
        inDoor = false;
    }

    private void Update()
    {
        if(inDoor && Input.GetKeyDown("e"))
        {
            transition.SetActive(true);
            canvas.enabled = false;
            Invoke("ChangeEscene", 0.3f);
        }
    }

    void ChangeEscene()
    {
        LoadingLevel.LevelLoading(LevelName);
    }
}
