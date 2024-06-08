using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //arma
    [Header("Gun")]
    public GameObject balaProjetil; //projetil
    public Transform player; //posição da arma
    public float forcaDoTiro; //velocidade da bala
    private bool tiro; //input do tiro

    //Melee attack
    [Header("Melle Atack Variable")]
    public Transform attackObject;
    public float attackRange;

    //player
    private float jumpSpeed = 14f;
    private float runSpeed = 9f;
    [SerializeField] private LayerMask jumpableGround;


    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private MovementState state;
    public Collider2D attackCol;
    private enum MovementState { idle, running, jumping, falling, aiming };

    float dirX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(dirX * runSpeed, rb.velocityY);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpSpeed);
        }

        UpdateAnimationState();

        //arma
        // tiro = Input.GetKeyDown(KeyCode.J);
        // Atirar();
    }

    private void UpdateAnimationState()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            if (dirX > 0f)
            {
                if (forcaDoTiro < 0)
                {
                    forcaDoTiro *= -1;
                }
                state = MovementState.running;
                sprite.flipX = false;
                if (attackObject.localPosition.x < 0)
                {
                    attackObject.localPosition = new Vector2(attackObject.localPosition.x * -1, attackObject.localPosition.y);
                }
            }
            else if (dirX < 0f)
            {
                if (forcaDoTiro > 0)
                {
                    forcaDoTiro *= -1;
                }
                state = MovementState.running;
                sprite.flipX = true;
                if (attackObject.localPosition.x > 0)
                {
                    attackObject.localPosition = new Vector2(-attackObject.localPosition.x, attackObject.localPosition.y);
                }
            }
            else
            {
                state = MovementState.idle;
            }
            //------------------------------
            if (rb.velocityY > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocityY < -.1f)
            {
                state = MovementState.falling;
            }
            //aiming in future
            // if (Input.GetMouseButton(1))
            // {
            //     state = MovementState.aiming;
            // }

            //--------------------------------
            if (Input.GetButtonDown("Fire1") && state == MovementState.idle)
            {
                anim.SetTrigger("Attack");
            }

            anim.SetInteger("state", (int)state);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    // private void Flip(int n, bool flip)
    // {
    //     sprite.flipX = flip;
    //     //attackObject.localPosition = new Vector2(attackObject.localPosition.x * n, attackObject.localPosition.y);

    //     if (n == 0)
    //     {
    //         if (attackObject.localPosition.x < 0)
    //         {
    //             attackObject.localPosition = new Vector2(attackObject.localPosition.x, attackObject.localPosition.y);
    //         }
    //     }
    //     else
    //     {
    //         if (attackObject.localPosition.x > 0)
    //         {
    //             attackObject.localPosition = new Vector2(-attackObject.localPosition.x, attackObject.localPosition.y);
    //         }
    //     }

    // }

    private void Atirar()
    {
        if (tiro == true)
        {
            anim.SetTrigger("Shoot");
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = new Vector2(player.position.x, player.position.y);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

    private void AttackStart()
    {
        attackCol.enabled = true;
    }



    private void AttackEnd()
    {
        attackCol.enabled = false;
    }
}

