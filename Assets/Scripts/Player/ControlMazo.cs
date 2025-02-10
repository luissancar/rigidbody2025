using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMazo : MonoBehaviour
{
    public GameObject swordToActivate; // mano jugador
    public GameObject swordToCollet;
    public bool tenemosEspada;
    public PlayerInput playerInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        playerInput.actions["SoltarEspada"].started += SoltarEspada;  
        swordToActivate.SetActive(false);
        tenemosEspada = false;
    }

    private void SoltarEspada(InputAction.CallbackContext context)
    {
        swordToActivate.SetActive(false);
        swordToCollet.transform.position = gameObject.transform.position + gameObject.transform.forward * 2f+
                                           gameObject.transform.up*1f;
        swordToCollet.SetActive(true);
        tenemosEspada = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Mazo"))
        {
            tenemosEspada = true;
            swordToCollet.SetActive(false);
            swordToActivate.SetActive(true);
        }
    }
}