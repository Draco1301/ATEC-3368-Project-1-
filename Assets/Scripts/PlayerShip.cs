using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour {
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 12f;
    [SerializeField] ParticleSystem _leftWing;
    [SerializeField] ParticleSystem _rightWing;
    [SerializeField] ParticleSystem _thrusterWing;
    public Vector3 _localVelocity;

    Rigidbody _rb = null;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        MoveShip();
        TurnShip();
        EmitParticles();
    }

    private void EmitParticles() {

        _localVelocity = transform.InverseTransformDirection(_rb.velocity);

        if (_localVelocity.z > 0) {
            if (!_leftWing.isPlaying) {
                _leftWing.Play();
            }
            if (!_rightWing.isPlaying) {
                _rightWing.Play();
            }
        } else if (Input.GetAxisRaw("Horizontal") > 0) {
            if (!_leftWing.isPlaying) {
                _leftWing.Play();
                _rightWing.Stop();
                _thrusterWing.Stop();

            }
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            if (!_rightWing.isPlaying) {
                _leftWing.Stop();
                _rightWing.Play();
                _thrusterWing.Stop();
            }
        } else {
            _leftWing.Stop();
            _rightWing.Stop();
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            if (!_thrusterWing.isPlaying) {
                _thrusterWing.Play();
            }
        } else { 
            _thrusterWing.Stop();
        }

    }

    private void MoveShip() {
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        _rb.AddForce(moveDirection);
    }

    private void TurnShip() {
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Kill() {
        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
    }

}
