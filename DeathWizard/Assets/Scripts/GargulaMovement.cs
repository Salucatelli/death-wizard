using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarollaMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject enemy;

    public float speed;
    public float distanceFollow;
    public float distanceStop;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < distanceFollow && Vector2.Distance(transform.position, target.position) > distanceStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.CompareTag("bala"))
        {
            Destroy(colision.gameObject);
            Destroy(this.gameObject);
        }
        if (colision.gameObject.CompareTag("Melee"))
        {
            Destroy(this.gameObject);
        }
    }
}
