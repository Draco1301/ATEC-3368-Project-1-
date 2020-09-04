using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    [SerializeField] Image _healthBar;
    [SerializeField] float _respawnTime = 3;
    [SerializeField] GameObject _art;
    [SerializeField] PlayerAudio _pAudio;
    [SerializeField] ParticleSystem _ps;

    public static int _health;
    private void Start() {
        _health = _maxHealth;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Asteroid>()) {
            collision.gameObject.GetComponent<Asteroid>().Die();
            _health--;
            _healthBar.fillAmount = (float)_health / (float)_maxHealth;
            if (_health <= 0) {
                StartCoroutine(DieAndRespawn());

            }
        }
    }

    public bool healthUP() {
        if (_health == _maxHealth) {
            return false;
        }

        _health++;
        _healthBar.fillAmount = (float)_health / (float)_maxHealth;
        return true;
    }

    IEnumerator DieAndRespawn() {

        _art.SetActive(false);
        this.GetComponent<PlayerShip>().enabled = false;
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        _pAudio.PlayDeath();
        _ps.Play();

        yield return new WaitForSeconds(_respawnTime);

        _art.SetActive(true);
        this.GetComponent<PlayerShip>().enabled = true;
        this.transform.position = new Vector3(0,0,0);
        _health = _maxHealth;
        _healthBar.fillAmount = 1;


    }

    public void InstantKill() {
        _health = 0;
        _healthBar.fillAmount = 0;
        StartCoroutine(DieAndRespawn());

    }
}
