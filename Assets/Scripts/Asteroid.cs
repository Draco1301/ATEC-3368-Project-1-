using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;
    [SerializeField] Collider _collider;
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _art;

    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _collider = GetComponent<Collider>();
        _audio = GetComponent<AudioSource>();
    }

    public void Die() {
        _ps?.Play();
        _audio?.Play();
        _collider.enabled = false;
        _art.SetActive(false);
        Destroy(this,2f);
    }
}
