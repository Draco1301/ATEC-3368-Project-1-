using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image MSHealthBar;
    [SerializeField] Image PSHealthBar;
    [SerializeField] Image Timer;
    [SerializeField] Text GameState;
    [SerializeField] Text Score;
    [SerializeField] Text GameOver;
    [SerializeField] Text ScoreGameOver;
    [SerializeField] GameObject WaitModeMenu;
    [SerializeField] Text repair;
    [SerializeField] Text laser;
    [SerializeField] Text cannon;
    [SerializeField] Text ricochet;
    [SerializeField] Button repairB;
    [SerializeField] Button laserB;
    [SerializeField] Button cannonB;
    [SerializeField] Button ricochetB;
    [SerializeField] Text speed;
    [SerializeField] Text health;
    [SerializeField] Text bomb;
    [SerializeField] Text paused;

    public static UIManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    public void setMotherHealthBar(float f) {
        MSHealthBar.fillAmount = f;
    }
    public void setPlayerHealthBar(float f) {
        PSHealthBar.fillAmount = f;
    }
    public void setTimer(float f) {
        Timer.fillAmount = f;
    }
    public void setGameState(string s) {
        GameState.text = s;
    }
    public void setScore(string s) {
        Score.text = s;
    }

    public void ShowGameOver(string s) {
        GameOver.enabled = true;
        ScoreGameOver.enabled = true;
        ScoreGameOver.text = s;
        Score.enabled = false;
    }

    public void WaitMenu(bool b) {
        WaitModeMenu.SetActive(b);
    }

    public void setRepair(string s, bool B) {
        repair.text = s;
        repairB.interactable = B;
    }

    public void setLaser(string s, bool B) {
        laser.text = s;
        laserB.interactable = B;

    }

    public void setCannon(string s, bool B) {
        cannon.text = s;
        cannonB.interactable = B;

    }

    public void setRicochet(string s, bool B) {
        ricochet.text = s;
        ricochetB.interactable = B;

    }

    public void showSpeed() {
        speed.enabled = true;
    }

    public void showBomb(int n) {
        bomb.enabled = true;
        bomb.text = "Bomb Bonus +" + n;
        Invoke("offBomb", 5);
    }

    public void showHealth() {
        health.enabled = true;
        Invoke("offHealth", 5);
    }

    public void offSpeed() {
        speed.enabled = false;
    }

    public void offBomb() {
        bomb.enabled = false;
    }

    public void offHealth() {
        health.enabled = false;
    }

    public void setPaused(bool b) {
        paused.enabled = b;
    }



}
