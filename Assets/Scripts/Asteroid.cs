using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] ParticleSystem _ps;
    [SerializeField] Collider _collider;
    [SerializeField] AudioSource _audio;
    [SerializeField] GameObject _art;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    private Vector3 rotationRate;
    private bool dying = false;

    // Start is called before the first frame update
    void Start()
    {   
        _ps = GetComponent<ParticleSystem>();
        _collider = GetComponent<Collider>();
        _audio = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        rotationRate.x = Random.Range(0,50);
        rotationRate.y = Random.Range(0,50);
        rotationRate.z = Random.Range(0,50);
    }

    private void Update() {
        _rb.velocity = transform.rotation * Vector3.forward * _speed;
        transform.position = new Vector3(transform.position.x,0,transform.position.z);
        _art.transform.Rotate(new Vector3(rotationRate.x * Time.deltaTime, rotationRate.y * Time.deltaTime, rotationRate.z * Time.deltaTime));
    }

    public void Die() {
        if (dying) {
            return;
        } else {
            dying = true;
        }

        if(_ps!=null)
            _ps?.Play();
        
        if (_audio != null)
            _audio?.Play();
        
        if (_collider != null)
        _collider.enabled = false;

        if (_art != null)
            _art.SetActive(false);
        Destroy(this.gameObject,2f);
    }

    public void setSpeed(float s) {
        _speed = s;
    }
}
