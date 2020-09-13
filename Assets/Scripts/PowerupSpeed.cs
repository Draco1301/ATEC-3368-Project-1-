using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _speedIncreaseAmount = 20;
    [SerializeField] float _powerupDuration = 5;
    [SerializeField] Gradient _powerColor;


    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;

    private Collider _colliderToDeactivate = null;
    public bool _poweredUp = false;
    static List<PowerupSpeed> _activePowerups = new List<PowerupSpeed>();


    private void Awake() {
        _colliderToDeactivate = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        PlayerMove playerShip = other.gameObject.GetComponent<PlayerMove>();

        if (playerShip != null && _poweredUp == false) {
            StartCoroutine(PowerupSequence(playerShip));
        } else if (other.gameObject.GetComponent<MotherShip>()) {
            Destroy(this.gameObject);
        }
    }

    IEnumerator PowerupSequence(PlayerMove playerShip) {

        _poweredUp = true;

        ActivatePowerup(playerShip);
        DisableObject();
        _activePowerups.Add(this);

        yield return new WaitForSeconds(_powerupDuration);

        _poweredUp = false;
        DeactivatePowerup(playerShip);

    }


    private void ActivatePowerup(PlayerMove playerShip) {

        foreach (PowerupSpeed ps in _activePowerups) {
            if (ps._poweredUp) {
                return;
            }
        }

        if (playerShip != null) {
            playerShip.SetSpeed(_speedIncreaseAmount);
            playerShip.ChangeBoosterColor(_powerColor);
        }
        UIManager.instance.showSpeed();
    }

    private void DisableObject() {
        _colliderToDeactivate.enabled = false;
        _visualsToDeactivate.SetActive(false);
    }

    private void DeactivatePowerup(PlayerMove playerShip) {
        foreach (PowerupSpeed ps in _activePowerups) {
            if (ps._poweredUp) {
                Destroy(this.gameObject);
                return;
            }
        }

        playerShip?.SetSpeed(-_speedIncreaseAmount);
        playerShip.RevertBoosterColor();
        UIManager.instance.offSpeed();
        Destroy(this.gameObject);

    }

}
