using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static int playerLife;
    private Animator anim;
    private Rigidbody2D rb;

    public Text lifeText;

    public List<GameObject> lifes;

    void Start()
    {
        playerLife = 3;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lifeText.text = "Vidas: " + playerLife;
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            Die();
            RestartLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Trap"))
        {
            Hit();
            lifeText.text = "Vidas: " + playerLife;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cherry"))
        {
            if (playerLife < 3)
            {
                playerLife++;
                lifeText.text = "Vidas: " + playerLife;
            }
            Destroy(collider.gameObject);
        }
    }

    private void Hit()
    {
        playerLife--;
        //Animação de bit futuramente
        if (playerLife == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
