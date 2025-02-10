using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] public float velocidad;
    public float velocidadSprint;
    public float velocidadBase;
    public float rotationSpeed;

    [Header("Jump")] public float jumpForce;
    public float groundCheckDistance = 0.1f;
    public float rayOffset = 0.1f;
    [SerializeField] private bool isGrounded;
    public float empiezaSalto;


    public bool running = false;
    private Rigidbody rb;
    private Vector2 entradaMovimiento;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    public void SetVelocidadBase()
    {
        velocidad = velocidadBase;
    }

    public void OnJump(InputValue value)
    {
        Debug.Log("SSSS");
        if (isGrounded)
        {
            Debug.Log("2222");
            animator.SetTrigger("Jump");
            StartCoroutine(ComienzaSalto());
        }
    }

    IEnumerator ComienzaSalto()
    {
        yield return new WaitForSeconds(empiezaSalto);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    public void OnMove(InputValue value)
    {
        entradaMovimiento = value.Get<Vector2>();
    }


    public void OnSprint(InputValue value)
    {
        running = !running;
        if (running)
            velocidad = velocidadSprint;
        else
            velocidad = velocidadBase;
    }

    private void FixedUpdate()
    {
        float rotation = entradaMovimiento.x * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotation);


        Vector3 movimiento = transform.forward * (entradaMovimiento.y * velocidad);
        rb.linearVelocity = new Vector3(movimiento.x, rb.linearVelocity.y, movimiento.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayStart = transform.position + Vector3.up * rayOffset;
        isGrounded = Physics.Raycast(rayStart, Vector3.down, groundCheckDistance);
        if (running)
        {
            animator.SetFloat("x", entradaMovimiento.x * 2);
            animator.SetFloat("y", entradaMovimiento.y * 2);
        }
        else
        {
            animator.SetFloat("x", entradaMovimiento.x);
            animator.SetFloat("y", entradaMovimiento.y);
        }

        float verticalVelocity = rb.linearVelocity.y;
        animator.SetFloat("velocidadVertical", verticalVelocity);
    }
}