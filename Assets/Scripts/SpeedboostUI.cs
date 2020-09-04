using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedboostUI : MonoBehaviour {
    public static SpeedboostUI Instance = null;
    [SerializeField] Image image;
    private float _timeTotal;
    private float _timeLeft;


    // Start is called before the first frame update
    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update() {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0) {
            _timeLeft = 0;
        }
        image.fillAmount = _timeLeft / _timeTotal;
    }

    public void SetTimer(float time) {
        _timeTotal = time;
        _timeLeft = time;
    }
}
