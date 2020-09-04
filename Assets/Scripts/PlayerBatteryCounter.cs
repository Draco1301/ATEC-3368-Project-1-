using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBatteryCounter : MonoBehaviour
{
    private int _batteryCount = 0;
    [SerializeField] Text _CountTest;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Battery") {
            Destroy(other.gameObject);
            _batteryCount++;
            _CountTest.text = $"Batteries Found: {_batteryCount}/3";

        }
        if (other.gameObject.tag == "MotherShip") {
            if(_batteryCount == 3){
                GameManager.Instance.ActivateWin();
            }
        }
    }
}
