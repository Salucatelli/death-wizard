using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    // public GameObject balaProjetil; //projetil
    // public Transform arma; //posição da arma
    // public float forcaDoTiro; //velocidade da bala

    // private bool tiro; //input do tiro
    // private bool flipX = false; //flip do personagem

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // void Update()
    // {
    //     tiro = Input.GetButtonDown("Fire1");

    //     Atirar();
    // }

    // private void Atirar()
    // {
    //     if (tiro == true)
    //     {
    //         GameObject temp = Instantiate(balaProjetil);
    //         temp.transform.position = arma.position;
    //         temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro, 0);
    //         Destroy(temp.gameObject, 3f);
    //     }
    // }
}
