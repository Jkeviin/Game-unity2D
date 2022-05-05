using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer = false;

    public enum Player {Frog, PinkMan, VirtualGuy, MaskDude};
    public Player playeSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerRenderer;

    void Start()
    {
        if (!enableSelectPlayer)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playeSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playerController[0];
                    break;
                case Player.PinkMan:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playerController[1];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playerRenderer[2];
                    animator.runtimeAnimatorController = playerController[2];
                    break;
                case Player.MaskDude:
                    spriteRenderer.sprite = playerRenderer[3];
                    animator.runtimeAnimatorController = playerController[3];
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case "PinkMan":
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playerController[2];
                break;
            case "MaskDude":
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playerController[3];
                break;
        }
    }
}
