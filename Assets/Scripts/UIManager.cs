using GM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    private bool paused = false;
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject pause;
    public GameObject play;
    public GameObject sound;
    public Text scorePlayUI;
    public Text highscorePlayUI;
    public Text scoreLoseUI;
    public Text highscoreLoseUi;
    public Text highscoreMenuUi;
    public Slider musicSlider;
    public Slider effectsSlider;
    public Text pauseText;
    #endregion

    #region Awake/Start/Update
    private void Awake()
    {
        GlobalManager.UIManager = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    #endregion

    #region Private/Public Functions
    public void SwitchPanel()
    {
        ResetPanels();
        string state = GlobalManager.GameManager.GetState().ToString();

        switch (state)
        {
            case "Menu":
                mainMenu.SetActive(true);
                ChangeHighscoreMenuUI();
                GlobalManager.AudioManager.MuteMusic();
                break;
            case "Play":
                play.SetActive(true);
                GlobalManager.AudioManager.UnmuteMusic();
                ChangeHighscorePlayUI();
                break;
            case "Pause":
                pause.SetActive(true);
                play.SetActive(true);
                break;
            case "Sound":
                sound.SetActive(true);
                SetSlidersValue();
                break;
            case "Lose":
                gameOver.SetActive(true);
                ChangeScoreLoseUI();
                ChangeHighscoreLoseUI();
                GlobalManager.AudioManager.MuteMusic();
                GlobalManager.AudioManager.PlayLose();
                break;
            default:
                mainMenu.SetActive(true);
                GlobalManager.AudioManager.MuteMusic();
                break;
        }
        GlobalManager.AudioManager.SetVolume();
    }

    private void ResetPanels()
    {
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        pause.SetActive(false);
        play.SetActive(false);
        sound.SetActive(false);
    }

    public void ChangeScorePlayUI(int score)
    {
        scorePlayUI.text = "Score: " + score;
    }
    public void ChangeHighscorePlayUI()
    {
        highscorePlayUI.text = "Highscore: " + GlobalManager.DataManager.GetHighscore();
    }

    public void ChangeScoreLoseUI()
    {
        scoreLoseUI.text = "Score: " + GlobalManager.GameManager.GetNumberOfCoins();
    }

    private void ChangeHighscoreLoseUI()
    {
        highscoreLoseUi.text = "Highscore: " + GlobalManager.DataManager.GetHighscore();
    }

    private void ChangeHighscoreMenuUI()
    {
        highscoreMenuUi.text = "Highscore: " + GlobalManager.DataManager.GetHighscore();
    }

    private void SetSlidersValue()
    {
        musicSlider.value = GlobalManager.DataManager.GetMusicVolume();
        effectsSlider.value = GlobalManager.DataManager.GetEffectsVolume();
    }
    public void ChangePauseText()
    {
        if (paused)
        {
            pauseText.text = "Pause";
            paused = false;
        } else
        {
            pauseText.text = "Resume";
            paused = true;
        }
    }
    #endregion
}
