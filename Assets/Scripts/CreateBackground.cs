using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour {
    [SerializeField] GameObject starPrefab;
    [SerializeField] GameObject _speedPowerup;
    [SerializeField] GameObject _bombPowerup;
    [SerializeField] GameObject _batteries;
    [SerializeField] GameObject _astro;
    [SerializeField] GameObject _heathPowerup;

    // Start is called before the first frame update
    void Awake() {
        for (int i=0;i<5;i++) {
            for (int n = 0; n < 100; n++) {
                Instantiate(starPrefab, new Vector3(Random.Range(-350, 350), -20-i*20, Random.Range(-350, 350)), Quaternion.Euler(0,0,0), this.transform);
            }
        }
        for (int i = 0; i < 100; i++) {
            Instantiate(_speedPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
        for (int i = 0; i < 50; i++) {
            Instantiate(_bombPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
        for (int i = 0; i < 3; i++) {
            Instantiate(_batteries, new Vector3(Random.Range(-280, 280), 0, Random.Range(-280, 280)), Quaternion.Euler(0, 0, 0), this.transform);

        }
        for (int i = 0; i < 1000; i++) {
            Instantiate(_astro, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
        for (int i = 0; i < 50; i++) {
            Instantiate(_heathPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
    }
}
