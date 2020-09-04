using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float _timeAllowed;
    [SerializeField] Text _text;
    public bool _play = true;


    // Update is called once per frame
    void Update() {
        if (_play) {
            _timeAllowed -= Time.deltaTime;
        }
        if (_timeAllowed < 0) {
            _timeAllowed = 0;
            GameManager.Instance.OutOfTime();
        }

        _text.text = $"{ Mathf.Floor(_timeAllowed / 60)}:"+ (_timeAllowed%60).ToString("00.00");
    }
}
