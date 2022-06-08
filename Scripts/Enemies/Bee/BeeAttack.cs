using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;

    public float distanceRaycast = 0.5f;
    private float coolDownAttack = 1.5f;
    private float actualCoolDownAtack = 0;

    public GameObject beeBullet;


    void Start()
    {
        actualCoolDownAtack = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        actualCoolDownAtack -= Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if(hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if(actualCoolDownAtack < 0)
                {
                    Invoke("LaunchBullet", 0.3f);
                    animator.Play("Attack");
                    actualCoolDownAtack = coolDownAttack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBulllet;

        newBulllet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
