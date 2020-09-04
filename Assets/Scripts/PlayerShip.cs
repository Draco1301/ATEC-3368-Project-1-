using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour {
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 12f;
    [SerializeField] Gradient _trailDefualtColor;
    [SerializeField] ParticleSystem _leftWing;
    [SerializeField] ParticleSystem _rightWing;
    [SerializeField] ParticleSystem _thruster;
    [SerializeField] PlayerAudio _pAudio;

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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            _rb.velocity = new Vector3(0,0,0);
        }
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
                _thruster.Stop();

            }
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            if (!_rightWing.isPlaying) {
                _leftWing.Stop();
                _rightWing.Play();
                _thruster.Stop();
            }
        } else {
            _leftWing.Stop();
            _rightWing.Stop();
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            if (!_thruster.isPlaying) {
                _thruster.Play();
                _pAudio.PlayThruster(true);
            }
        } else {
            _thruster.Stop();
            _pAudio.PlayThruster(false);

        }

    }

    public void SetSpeed(float speedChange) {
        _moveSpeed += speedChange;
    }

    public void ChangeBoosterColor(Gradient grad) {
        var trail = _leftWing.trails;
        trail.colorOverLifetime = grad;
        trail = _rightWing.trails;
        trail.colorOverLifetime = grad;
    }

    public void RevertBoosterColor() {
        var trail = _leftWing.trails;
        trail.colorOverLifetime = _trailDefualtColor;
        trail = _rightWing.trails;
        trail.colorOverLifetime = _trailDefualtColor;
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

    public void StopMoving() {
        _rb.velocity = new Vector3(0,0,0);
        _moveSpeed = 0;
        _turnSpeed = 0;
    }

}
