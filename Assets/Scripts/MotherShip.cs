using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] GameObject art;
    [SerializeField] ParticleSystem ps;
    private int health;
    public int Health { get => health; }
    public int MaxHealth { get => maxHealth; }

    private void Start() {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision) {
        Asteroid astro = collision.gameObject.GetComponent<Asteroid>();
        if (astro != null) {
            health -= 1;
            UIManager.instance.setMotherHealthBar((float)health/maxHealth);
            astro.Die();
        }
    }

    public void addHealth(int h) {
        health += h;
        if (health > maxHealth) {
            health = maxHealth;
        }
        UIManager.instance.setMotherHealthBar((float)health / maxHealth);
    }

    public void Die() {
        art.SetActive(false);
        ps.Play();
    }
    
}
