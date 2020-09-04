using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTracker : MonoBehaviour {
    GameObject[] _batteryList;
    [SerializeField] GameObject _pointer;
    [SerializeField] GameObject _Final;

    // Start is called before the first frame update
    void Start() {
        _batteryList = GameObject.FindGameObjectsWithTag("Battery");
        foreach (GameObject b in _batteryList) {
            GameObject temp = Instantiate(_pointer, this.transform);
            temp.GetComponent<Pointer>()._ObjToTrack = b;
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (GameObject b in _batteryList) {
            if (b != null)
                return;
        }
        GameObject temp = Instantiate(_pointer, this.transform);
        temp.GetComponent<Pointer>()._ObjToTrack = _Final;
        this.enabled = false;
    }
}
