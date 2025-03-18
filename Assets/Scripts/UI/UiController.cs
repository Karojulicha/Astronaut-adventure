using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Animator transitionAnimator;
    public Slider musicSlider, sfxSlider;


    public void StartGame()
    {
        GameManager.instance.Play();
        AudioManager.Instance.StopMusicInitial();
    }


    public void CheckMute()
    {
        AudioManager.Instance.MuteAll();
    }
    public void ChangeMusicVolume()
    {
        AudioManager.Instance.MusicVolumeControl(musicSlider.value);
    }
    public void ChangeSfxVolume()
    {
        AudioManager.Instance.SFXVolumeControl(sfxSlider.value);
    }
}
