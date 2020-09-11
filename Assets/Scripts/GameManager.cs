using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _winText;
    [SerializeField] AudioSource _audio;
    public static GameManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }


    public void ActivateWin() {
        _winText.enabled = true;
        _winText.text = "You repaired the Mothership!\nYou Win!";
        stopPlayer();
        _audio.Play();
        this.GetComponent<GameTimer>()._play = false;
    }

    public void OutOfTime() {
        _winText.enabled = true;
        _winText.text = "You ran out of time\nThe Mothership was destroyed\nHit Backspace to replay";
        stopPlayer();
    }

    public void stopPlayer() {
        GameObject.FindObjectOfType<PlayerMove>().StopMoving();
    }

}
