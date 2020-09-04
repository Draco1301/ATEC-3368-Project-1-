using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    [SerializeField] float _timeAllowed;
    [SerializeField] Text _timerText;
    private float _timeLeft;

    private void Update() {

        if (PlayerHealth._health > 0) {


            if (Mathf.Abs(this.transform.position.x) > 350 || Mathf.Abs(this.transform.position.z) > 350) {
                _timeLeft -= Time.deltaTime;
                _timerText.enabled = true;

                if (_timeLeft <= 0) {
                    _timeLeft = 0;
                }
                _timerText.text = $"Warning Return to Area: \n{_timeLeft,4:F2}";


            } else {
                _timerText.enabled = false;
                _timeLeft = _timeAllowed;

            }
        }
        if (_timeLeft <= 0 && PlayerHealth._health > 0) {
            _timerText.text = $"Return to area before time runs out";
            this.GetComponent<PlayerHealth>().InstantKill();
        }
    }

}
