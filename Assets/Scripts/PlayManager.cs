using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;

    enum state { play, wait, gameOver, end };
    state _GameState = state.wait;

    [SerializeField] Asteroid astro;
    [SerializeField] MotherShip motherShip;
    [SerializeField] MothershipPowerUps MSUP;
    [SerializeField] MovePowerUp[] powerUps;

    //Starting values
    [SerializeField] float _astroSpawnRate = 1.5f;
    [SerializeField] float _powerUpRate = 12f;
    [SerializeField] float _astroSpeed = 3f;

    //inbetween
    [SerializeField] float _astroidSpeedIncreaseRate;
    [SerializeField] float _astroidSpawnIncreaseRate;

    //States
    [SerializeField] int _roundNum = 0;
    [SerializeField] float _playModeLength = 30;
    private float _playModeTimer = 0;
    private bool _waitModeActive = false;
    private float _astroTimer = 0;
    private float _powerTimer = 0;

    //powerups
    [SerializeField] int _score = 0;
    [SerializeField] int _totalscore = 0;
    int repairCounter;
    [SerializeField] int cannonCost;
    [SerializeField] int laserCost;
    [SerializeField] int ricochetCost;


    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {


        switch (_GameState) {
            case state.wait:
                WaitState();
                break;
            case state.play:
                PlayState();
                break;
            case state.gameOver:
                GameOver();
                break;
        }

        if (motherShip.Health <= 0 && _GameState != state.end) {
            _GameState = state.gameOver;
        }

    }

    private void GameOver() {
        motherShip.Die();
        
        FindObjectOfType<PlayerMove>().enabled = false;
        FindObjectOfType<PlayerShoot>().enabled = false;

        UIManager.instance.ShowGameOver("Score: " + _totalscore.ToString("000000000"));

        Asteroid[] astros = GameObject.FindObjectsOfType<Asteroid>();
        foreach (Asteroid a in astros) {
            a.Die();
        }

        _GameState = state.end;
    }

    private void PlayState() {


        _astroTimer -= Time.deltaTime;
        if (_astroTimer < 0) {
            _astroTimer = _astroSpawnRate - _astroidSpawnIncreaseRate * _roundNum;
            if (_astroTimer < 0.2) {
                _astroTimer = 0.2f;
            }
            SpawnAsteroid();
        }

        _powerTimer -= Time.deltaTime;
        if (_powerTimer < 0) {
            _powerTimer = _powerUpRate;
            SpawnPowerUp();
        }

        UIManager.instance.setTimer(_playModeTimer/_playModeLength);
        
        _playModeTimer -= Time.deltaTime;
        if (_playModeTimer < 0) {
            _GameState = state.wait;
            _waitModeActive = true;

            UIManager.instance.setTimer(0);
            UIManager.instance.WaitMenu(true);

            GameObject.FindObjectOfType<PlayerHealth>().healthUP();

            Asteroid[] astros = GameObject.FindObjectsOfType<Asteroid>();
            foreach (Asteroid a in astros) {
                a.Die();
                addScore(100);
            }

            updateMenu();
        }
    }

    private void WaitState() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            _waitModeActive = false;
        }

        if (!_waitModeActive) {

            _roundNum += 1;

            UIManager.instance.setGameState("Round " + _roundNum);
            UIManager.instance.WaitMenu(false);
            _powerTimer = _powerUpRate;

            _GameState = state.play;
            _playModeTimer = _playModeLength;
        }
    }

    private void SpawnAsteroid() {
        Vector2 pos = UnityEngine.Random.insideUnitCircle.normalized * 30;
        GameObject temp = Instantiate(astro.gameObject, new Vector3(pos.x, 0, pos.y), Quaternion.Euler(0, 0, 0), this.transform);

        if (_astroSpeed + _astroidSpeedIncreaseRate * _roundNum <= 7.5f) {
            temp.GetComponent<Asteroid>().setSpeed(_astroSpeed + _astroidSpeedIncreaseRate * _roundNum);
        } else {
            temp.GetComponent<Asteroid>().setSpeed(7.5f);
        }
        temp.transform.LookAt(new Vector3(0,0,0));
    }

    private void SpawnPowerUp() {
        int temp = UnityEngine.Random.Range(0, powerUps.Length);

        Vector2 pos = UnityEngine.Random.insideUnitCircle.normalized * 30;
        Instantiate(powerUps[temp].gameObject, new Vector3(pos.x, 0, pos.y), Quaternion.Euler(0, 0, 0), this.transform).transform.LookAt(new Vector3(0, 0, 0));

    }

    public void addScore(int i) {
        _score += (int)(i * (1+_roundNum * 0.1f));
        _totalscore += (int)(i * (1+_roundNum * 0.1f));
        UIManager.instance.setScore(_score.ToString("000000000"));
    }

    public void repairMotherShip() {
        _score -= 500 * (int)Math.Pow(2,repairCounter);
        UIManager.instance.setScore(_score.ToString("000000000"));

        repairCounter++;
        motherShip.addHealth(1);

        updateMenu();

    }
    public void upgradeCannons() {
        _score -= cannonCost * (MSUP.cannonLV + 1);
        UIManager.instance.setScore(_score.ToString("000000000"));
        
        MSUP.cannonLV++;

        updateMenu();

    }
    public void upgradeLaser() {
        _score -= laserCost * (MSUP.laserLV + 1);
        UIManager.instance.setScore(_score.ToString("000000000"));

        MSUP.laserLV++;

        updateMenu();

    }
    public void upgradeRicochet() {
        _score -= ricochetCost * (BulletManager.ricochetLV + 1);
        UIManager.instance.setScore(_score.ToString("000000000"));

        BulletManager.ricochetLV++;

        updateMenu();
    }

    public void updateMenu() {
        bool temp = _score >= 500 * (int)Math.Pow(2, repairCounter) && motherShip.Health != motherShip.MaxHealth;
        UIManager.instance.setRepair($"Repair Mothership ({500 * (int)Math.Pow(2, repairCounter)})", temp);

        temp = _score >= cannonCost * (MSUP.cannonLV + 1);
        UIManager.instance.setCannon($"Mothership Cannons Lv{MSUP.cannonLV + 1} ({cannonCost * (MSUP.cannonLV + 1)})", temp);

        temp = _score >= laserCost * (MSUP.laserLV + 1);
        UIManager.instance.setLaser($"Mothership Lasers Lv{MSUP.laserLV + 1} ({laserCost * (MSUP.laserLV + 1)})", temp);

        temp = _score >= ricochetCost * (BulletManager.ricochetLV + 1);
        UIManager.instance.setRicochet($"Ricochet Lasers Lv{BulletManager.ricochetLV + 1} ({ricochetCost * (BulletManager.ricochetLV + 1)})", temp);
    }

    public bool inPlayMode() {
        return _GameState == state.play;
    }
}
