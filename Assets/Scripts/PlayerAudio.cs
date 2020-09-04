using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
   [SerializeField] AudioSource _audio;
   [SerializeField] AudioClip _audioThruster;
   [SerializeField] AudioClip _audioDeath;

    public void PlayThruster(bool b) {
        if (b) {
            if (!_audio.isPlaying) {
                _audio.clip = _audioThruster;
                _audio.loop = true;
                _audio.Play();
            }
        } else {
            _audio.Stop();
        }
    }

    public void PlayDeath() {
        if (_audio.isPlaying) {
            _audio.Stop();
        }
        _audio.clip = _audioDeath;
        _audio.loop = false;
        _audio.Play();
    }
}
