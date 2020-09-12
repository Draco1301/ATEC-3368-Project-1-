using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MothershipPowerUps : MonoBehaviour
{
    public int cannonLV = 0;
    public int laserLV = 0;

    float cannonRate = 5;
    float cannonTimer = 0;

    [SerializeField] Collider laser_1;
    [SerializeField] Collider laser_2;
    [SerializeField] Collider laser_3;
    [SerializeField] Collider laser_4;
    [SerializeField] ParticleSystem ps1;
    [SerializeField] ParticleSystem ps2;
    [SerializeField] ParticleSystem ps3;
    [SerializeField] ParticleSystem ps4;

    float laserRate = 5;
    float laserTimer = 0;
    float laserOnRate = 3;
    float laserOnTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (PlayManager.instance.inPlayMode()) {
            if (cannonLV > 0) {
                Cannons();
            }
            if (laserLV > 0) {
                Lasers();
            }
        } else {
            laser_1.enabled = false;
            laser_2.enabled = false;
            laser_3.enabled = false;
            laser_4.enabled = false;

            if (ps1.isPlaying) {
                ps1.Stop();
                ps2.Stop();
                ps3.Stop();
                ps4.Stop();
            }
        }
    }

    private void Cannons() {
        cannonTimer -= Time.deltaTime;
        if (cannonTimer < 0) {
            cannonTimer = Math.Max(cannonRate - cannonLV, 0.5f);

            int num = (cannonLV > 5 ? cannonLV  : 5);
            for (int i = 0; i < num; i++) {
                Vector2 pos = UnityEngine.Random.insideUnitCircle.normalized * 7;
                float angle = 90f - Mathf.Atan2(pos.y,pos.x) * Mathf.Rad2Deg;
                
                BulletManager.Instance.spawnBullet(new Vector3(pos.x, 0, pos.y), Quaternion.Euler(0, angle, 0), 1);
            } 
        }
    }

    private void Lasers() {

        laserTimer -= Time.deltaTime;
        if (laserTimer < 0) {
            laserOnTimer -= Time.deltaTime;

            laser_1.enabled = true;
            laser_2.enabled = true;
            laser_3.enabled = true;
            laser_4.enabled = true;

            if (!ps1.isPlaying) {
                ps1.gameObject.SetActive(true);
                ps2.gameObject.SetActive(true);
                ps3.gameObject.SetActive(true);
                ps4.gameObject.SetActive(true);
                ps1.Play();
                ps2.Play();
                ps3.Play();
                ps4.Play();
            }

            if (laserOnTimer < 0) {
                laserOnTimer = laserOnRate;
                laserTimer = laserRate;
            }
        } else {
            laser_1.enabled = false;
            laser_2.enabled = false;
            laser_3.enabled = false;
            laser_4.enabled = false;
            
            if (ps1.isPlaying) {
                ps1.Stop();
                ps2.Stop();
                ps3.Stop();
                ps4.Stop();
                ps1.gameObject.SetActive(false);
                ps2.gameObject.SetActive(false);
                ps3.gameObject.SetActive(false);
                ps4.gameObject.SetActive(false);
            }
        }


        transform.Rotate(new Vector3(0, 3 * laserLV * Time.deltaTime, 0));
    }
}
