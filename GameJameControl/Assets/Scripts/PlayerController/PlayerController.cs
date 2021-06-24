using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;
public class PlayerController : Singleton<PlayerController>
{
    public float moveSpeed;
    public float maxSpeed;

    private Vector2 m_Move;
    private Rigidbody rb;
    private bool canDodge = true;

    private float dodgeCooldown = 1f;
    public float actCooldown;

    public float rollAmount = 2000f;



    public int health = 3;
    // Start is called before the first frame update
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void OnDodgeRoll(InputAction.CallbackContext context)
    {

        if (context.phase != InputActionPhase.Performed)
        {
            return;
        }
        DodgeRoll();

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canDodge = true;
    }

    public void Update()
    {
        Move(m_Move);

        if (actCooldown <= 0)
        {
            canDodge = true;

        }
        else
        {

            canDodge = false;

            actCooldown -= Time.deltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        Vector3 force = new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;
        rb.AddForce(force);


        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg, 0);
        transform.rotation = q;
    }

    private void DodgeRoll()
    {
        if (canDodge)
        {
            actCooldown = dodgeCooldown;

            rb.AddForce(transform.forward * rollAmount, ForceMode.Force);

        }
    }
}
