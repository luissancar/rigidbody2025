using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;
    private ControlMazo mazoScript;

    public bool mazoActivo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions["Attack"].started += Golpear;
        mazoScript = GetComponent<ControlMazo>();
    }

    private void Golpear(InputAction.CallbackContext context)
    {
        Debug.Log("Golpear");
        if (mazoScript.tenemosEspada)
        {
            animator.SetTrigger("Golpear");
            mazoActivo = true;
            StartCoroutine(DesactMazo(2f));
        }
    }

    private IEnumerator DesactMazo(float time)
    {
        yield return new WaitForSeconds(time);
        mazoActivo = false;
    }
}