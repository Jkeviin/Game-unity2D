using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

    public AudioSource clipDie;

    public AudioSource clipHit;

    public GameObject[] hearts;
    private int life;

    Rigidbody2D rb2D;

    public GameObject destroyParticle;
    public PlayerMove playerMove;

    public SpriteRenderer spriteRenderer;

    public SpriteRenderer spriteRendererDestroy;

    public Collider2D colliderPlayer;

    private float checkPointPositionX, checkPointPositionY;

    public Animator animator;
     
    void Start()
    {

        spriteRendererDestroy = destroyParticle.GetComponent<SpriteRenderer>();

        rb2D = GetComponent<Rigidbody2D>();

        life = hearts.Length;


        if(PlayerPrefs.GetFloat("checkPointPositionX")!= 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        clipHit.Play();
        if (life<1)
        {
            clipDie.Play();
            rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            colliderPlayer.enabled = false;
            playerMove.enabled = false;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 3f);
            Destroy(hearts[0].  gameObject);
            Invoke("JumpDie", 0.2f);
            
        }
        else if (life<2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if (life<3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamaged()
    {
        life--;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 3f);
        CheckLife();
    }


    private void JumpDie()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
       
        if (spriteRenderer.flipX == false)
        {
            spriteRendererDestroy.flipX = false;
        }
        else if (spriteRenderer.flipX == true){

            spriteRendererDestroy.flipX = true;
        }

        destroyParticle.SetActive(true);

        spriteRenderer.enabled = false;
        destroyParticle.SetActive(true);    
        Invoke("ChangeEscene", 0.6f);
    }
    private void ChangeEscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
