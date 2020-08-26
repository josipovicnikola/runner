using GM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int numberOfCoins = 0;
    public enum GameState
    {
        Win,
        Lose,
        Pause,
        Play,
        Menu,
        Sound
    }
    private GameState state=GameState.Menu;
    public Text coinsText;

    private void Awake()
    {
        GlobalManager.GameManager = this;
        SetAppSettings();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Replay") == 1)
        {
            state = GameState.Play;
            PlayerPrefs.SetInt("Replay", 2);
        }
        GlobalManager.UIManager.SwitchPanel();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void SetAppSettings()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    public void ChangeState(string state)
    {
        switch (state)
        {
            case "Menu":
                this.state = GameState.Menu;
                break;
            case "Play":
                this.state = GameState.Play;
                break;
            case "Pause":
                this.state = GameState.Pause;
                break;
            case "Lose":
                this.state = GameState.Lose;
                break;
            case "Sound":
                this.state = GameState.Sound;
                break;
            default:
                this.state = GameState.Menu;
                break;
        }
    }
    public GameState GetState()
    {
        return state;
    }

    public void Play_Clicked()
    {
        GlobalManager.GameManager.ChangeState("Play");
        GlobalManager.UIManager.SwitchPanel();
        GlobalManager.AudioManager.PlayClick();
    }

    public void Back_Clicked()
    {
        GlobalManager.AudioManager.PlayClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void Replay_Clicked()
    {
        PlayerPrefs.SetInt("Replay", 1);
        GlobalManager.AudioManager.PlayClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause_Clicked()
    {
        if (state.ToString() == "Play")
        {
            GlobalManager.GameManager.ChangeState("Pause");
        }
        else
        {
            GlobalManager.GameManager.ChangeState("Play");
        }
        GlobalManager.UIManager.ChangePauseText();
        GlobalManager.UIManager.SwitchPanel();
        GlobalManager.AudioManager.PlayClick();
    }

    public void ExitSound_Clicked()
    {
        GlobalManager.GameManager.ChangeState("Menu");
        GlobalManager.UIManager.SwitchPanel();
        GlobalManager.AudioManager.PlayClick();
    }

    public void Sound_Clicked()
    {
        GlobalManager.GameManager.ChangeState("Sound");
        GlobalManager.UIManager.SwitchPanel();
        GlobalManager.AudioManager.PlayClick();
    }

    public void AddCoin()
    {
        numberOfCoins++;
        int highscore = GlobalManager.DataManager.GetHighscore();
        if (numberOfCoins > highscore)
        {
            GlobalManager.DataManager.SaveHighscore(numberOfCoins);
            GlobalManager.UIManager.ChangeHighscorePlayUI();
        }
        GlobalManager.UIManager.ChangeScorePlayUI(numberOfCoins);
    }

    public int GetNumberOfCoins()
    {
        return numberOfCoins;
    }
}
