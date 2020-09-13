using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInput : MonoBehaviour
{
    bool paused = false;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            ReloadLevel();
        } else
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            paused = !paused;
            UIManager.instance.setPaused(paused);
        }
        if (paused) {
            Time.timeScale = 0;
        } else { 
            Time.timeScale = 1;
        }
    }

    private void ReloadLevel() {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}
