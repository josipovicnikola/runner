using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource playerSource;
    [SerializeField]
    private AudioSource environmentSource;
    [SerializeField]
    readonly private AudioClip lose;
    [SerializeField]
    readonly private AudioClip coin;
    [SerializeField]
    readonly private AudioClip click;
    
    private int muted = 0;

    private void Awake()
    {
        GlobalManager.AudioManager = this;
    }

    void Start()
    {
        muted = PlayerPrefs.GetInt("muted", 0);
        environmentSource.loop = true;
        UpdateSources();
    }


    public void UpdateSources()
    {
        if (muted == 0)
        {
            playerSource.mute = false;
            environmentSource.mute = false;
            //GlobalManager.UIManager.UpdateSoundImage(true);
        }
        else
        {
            playerSource.mute = true;
            environmentSource.mute = true;
            //GlobalManager.UIManager.UpdateSoundImage(false);
        }
    }

    public void PlayLose()
    {
        if (muted == 0 && playerSource != null & lose != null)
        {
            playerSource.clip = lose;
            playerSource.Play();
        }
    }

    public void PlayCoin()
    {
        if (muted == 0 && playerSource != null & coin != null)
        {
            playerSource.clip = coin;
            playerSource.Play();
        }
    }

    public void PlayClick()
    {
        if (muted == 0 && playerSource != null & click != null)
        {
            playerSource.clip = click;
            playerSource.Play();
        }
    }


    public void ToggleMute()
    {
        if (muted == 0)
        {
            muted = 1;
            UpdateSources();
        }
        else
        {
            muted = 0;
            UpdateSources();
        }
        PlayerPrefs.SetInt("muted", muted);
    }
    public void SetVolume()
    {
        environmentSource.volume = GlobalManager.DataManager.GetMusicVolume();
        playerSource.volume = GlobalManager.DataManager.GetEffectsVolume();

    }
    public void MuteMusic()
    {
        environmentSource.mute = true;
    }

    public void UnmuteMusic()
    {
        environmentSource.mute = false;
    }

    public void OnMusicValueChanged(float value)
    {
        environmentSource.volume = value;
        GlobalManager.DataManager.SetMusicVolume(value);
    }

    public void OnEffectsValueChanged(float value)
    {
        playerSource.volume = value;
        GlobalManager.AudioManager.PlayCoin();
        GlobalManager.DataManager.SetEffectsVolume(value);
    }
}
