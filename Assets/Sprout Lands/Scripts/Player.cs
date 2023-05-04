using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //----------- properties
    public Vector3 Velocity
    {
        get => Vector3.Normalize(velocity);
    }

    public Vector3 LastVelocity
    {
        get => Vector3.Normalize(lastVelocity);
    }

    // ---------- fields
    private Rigidbody2D _rigidbody2D;

    private Vector2 inputs = Vector2.zero;
    private float speedMult = 2f;

    private Vector2 velocity = Vector2.zero;
    private Vector2 lastVelocity = Vector2.zero;


    // ---------- unity methods
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 position = new(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"));
        transform.position = position;
    }


    private void Update()
    {
        GetInputs();
        Move();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);    
    }

    // ---------- class methods
    private void GetInputs()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        if (inputs.magnitude != 0)
        {
            lastVelocity = velocity;
        }
        velocity = inputs * speedMult;
        _rigidbody2D.velocity = velocity;
    }
}

