using GM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
        GlobalManager.DataManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetHighscore()
    {
        return PlayerPrefs.GetInt("Highscore");
    }

    public void SaveHighscore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume");
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public float GetEffectsVolume()
    {
        return PlayerPrefs.GetFloat("EffectsVolume");
    }

    public void SetEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
}
