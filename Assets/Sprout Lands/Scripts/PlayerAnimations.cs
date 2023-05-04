using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour

{

    // ----------- propierties


    // ----------- fields
    private Player _player;
    private Animator _animator;

    // ----------- unity methods
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        _animator.SetFloat("velocityX", _player.Velocity.x);
        _animator.SetFloat("velocityY", _player.Velocity.y);

        _animator.SetFloat("lastVelocityX", _player.LastVelocity.x);
        _animator.SetFloat("lastVelocityY", _player.LastVelocity.y);

    }
}

