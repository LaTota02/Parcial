using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int fuerzaDeSalto = 5;
    public bool estaSaltando;
    private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        animacion = gameObject.GetComponent<Animator>();
        animacion.SetBool("salto", false);
        estaSaltando = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaSaltando == false)
        {
            animacion.SetBool("salto", true);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, fuerzaDeSalto, 0);
            estaSaltando = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && estaSaltando == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            estaSaltando = false;
        }

        if (collision.gameObject.tag == "obstaculo")
        {
            Time.timeScale = 0;
        }
    }
}