using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{
    [SerializeField] GameObject _speedPowerup;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++) {
            Instantiate(_speedPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
