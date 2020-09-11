using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {
    
    Rigidbody _rb = null;

    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] GameObject _art;
    [SerializeField] Gradient _trailDefualtColor;
    [SerializeField] ParticleSystem _leftWing;
    [SerializeField] ParticleSystem _rightWing;
    [SerializeField] ParticleSystem _thruster;
    [SerializeField] PlayerAudio _pAudio;

    public Vector3 _localVelocity;
    
    private Vector3 _point;
    private Vector3 _mousePos;



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

        _localVelocity = _rb.velocity;

        if (_localVelocity.magnitude > 1) {

            if (!_leftWing.isPlaying) {
                _leftWing.Play();
            }
            if (!_rightWing.isPlaying) {
                _rightWing.Play();
            }
            if (!_thruster.isPlaying) {
                _thruster.Play();
            }
            _pAudio.PlayThruster(true);
        } else {
            _leftWing.Stop();
            _rightWing.Stop();
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
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal") * _moveSpeed, 0f, Input.GetAxisRaw("Vertical") * _moveSpeed);
        if (moveDirection.magnitude == 0) {
            _rb.drag = 2f;
        } else {
            _rb.drag = 0.5f;
        }
        _rb.AddForce(moveDirection);
    }

    private void TurnShip() {
        _mousePos = Input.mousePosition;
        _point = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, 30f));

        _art.transform.LookAt(_point);
    }

    public void Kill() {
        this.gameObject.SetActive(false);
    }

    public void StopMoving() {
        _rb.velocity = new Vector3(0,0,0);
        _moveSpeed = 0;
    }

    public Quaternion GetRotation() {
        return _art.transform.rotation;
    }

}
