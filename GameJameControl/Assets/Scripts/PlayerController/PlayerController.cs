using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;
public class PlayerController : Singleton<PlayerController>
{
    public float moveSpeed;
    private Vector2 m_Move;
    public Rigidbody rb;

    private Quaternion initialRot;


    public int health = 3;
    // Start is called before the first frame update
    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        initialRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        //var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        //transform.position += new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;
        //float angle = Vector3.SignedAngle(new Vector3(direction.x, 0, direction.y), transform.forward, Vector3.up);

        Vector3 force = new Vector3(direction.x, 0, direction.y) * scaledMoveSpeed;
        rb.AddForce(force);
        //transform.right = direction;

        //transform.rotation *= Quaternion.Euler(0, angle, 0);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg, 0);
        transform.rotation = q;
    }

    private void DodgeRoll()
    {

    }
}
