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
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();

        if (playerShip != null && _poweredUp == false) {
            StartCoroutine(PowerupSequence(playerShip));
        }
    }

    IEnumerator PowerupSequence(PlayerShip playerShip) {

        _poweredUp = true;

        ActivatePowerup(playerShip);
        DisableObject();
        _activePowerups.Add(this);

        yield return new WaitForSeconds(_powerupDuration);

        _poweredUp = false;
        DeactivatePowerup(playerShip);

    }


    private void ActivatePowerup(PlayerShip playerShip) {
        SpeedboostUI.Instance.SetTimer(_powerupDuration);


        foreach (PowerupSpeed ps in _activePowerups) {
            if (ps._poweredUp) {
                return;
            }
        }

        if (playerShip != null) {
            playerShip.SetSpeed(_speedIncreaseAmount);
            playerShip.ChangeBoosterColor(_powerColor);
        }
    }

    private void DisableObject() {
        _colliderToDeactivate.enabled = false;
        _visualsToDeactivate.SetActive(false);
    }

    private void DeactivatePowerup(PlayerShip playerShip) {
        foreach (PowerupSpeed ps in _activePowerups) {
            if (ps._poweredUp) {
                Destroy(this.gameObject);
                return;
            }
        }

        playerShip?.SetSpeed(-_speedIncreaseAmount);
        playerShip.RevertBoosterColor();
        Destroy(this.gameObject);

    }

}
