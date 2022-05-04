using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public enum Player {Frog, VirtualFuy, PinkMan, MaskDude};
    public Player playeSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerRenderer;

    void Start()
    {
        switch (playeSelected)
        {
            case Player.Frog:
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case Player.VirtualFuy:
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            case Player.PinkMan:
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playerController[2];
                break;
            case Player.MaskDude:
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playerController[4];
                break;
            default:
                Debug.Log("None selected.");
                break;
        }
    }
}
