using System;
using UnityEditor;
using UnityEngine;

public class GolpeEne : MonoBehaviour
{
    
    private Animator animator;
    public Attack attack;
    public Blood blood;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        if (other.tag == "Mazo" && attack.mazoActivo)
        {
            Death();
        }
    }

    private void Death()
    {
        blood.ShowBlood();
        animator.SetTrigger("Muerto");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
    }
}
