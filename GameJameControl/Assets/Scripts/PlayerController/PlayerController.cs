using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Interactions;
using System;
public class PlayerController : Singleton<PlayerController>
{
    public float moveForce = 1000f;
    public float maxSpeed;

    private Vector2 m_Move;
    private Rigidbody rb;
    private bool canDodge = true;

    public float dodgeCooldown = 1f;
    public float actCooldown;

    public float rollAmount = 2000f;

    public Animator anim;

    public float health = 3f;
    public float invincibleAmount;
    public float invincibleDuration = 0.5f;
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

        if (invincibleAmount > 0)
        {
            invincibleAmount -= Time.deltaTime;
        }

        if (actCooldown <= 0)
        {
            canDodge = true;

        }
        else
        {

            canDodge = false;
            if (actCooldown > 0)
                actCooldown -= Time.deltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveForce * Time.deltaTime;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        Vector3 force = new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;
        rb.AddForce(force);


        //Quaternion q = new Quaternion();
        //q.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg, 0);
        //transform.rotation = q;

        animationSet(direction);

    }

    public void animationSet(float x, float y)
    {
        anim.SetFloat("Xpos", x); anim.SetFloat("Ypos", y);
    }
    public void animationSet(Vector2 direction)
    {
       // Debug.Log("Pos X:" + direction.x + " | Pos Y:" + direction.y);
        anim.SetFloat("Xpos", direction.x); anim.SetFloat("Ypos", direction.y);
        
    }

    private void DodgeRoll()
    {
        if (canDodge)
        {

            actCooldown = dodgeCooldown;
            Invincible(invincibleDuration);
            rb.AddForce(transform.forward * rollAmount, ForceMode.Force);

        }
    }

    public void TakeDamage(float amount)
    {
        if (invincibleAmount <= 0)
        {
            if (health >= 0)
            {
                health -= amount;
            }
            if (health <= 0)
                health = 0f;
        }
    }

    public void Invincible(float duration)
    {
        invincibleAmount = invincibleDuration;

    }
}
