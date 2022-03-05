using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
using Vion;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region References
        [Header("Text Asset")]
        [SerializeField]
        private TextAsset gameTextAsset = null;

        [Header("Audio")]
        [SerializeField]
        private AudioManager Audio = null;

        [Header("I/O Services")]
        [SerializeField]
        private VionInputService InputService = null;

        [SerializeField]
        private VionOutputService OutputService = null;

        [Header("UI Fields")]
        [SerializeField]
        private TextMeshProUGUI CurrentRegionText = null;

        [SerializeField]
        private TextMeshProUGUI CurrentLocationText = null;

        [SerializeField]
        private TextMeshProUGUI CharacterNameText = null;

        [SerializeField]
        private TextMeshProUGUI ScoreText = null;

        [SerializeField]
        private TextMeshProUGUI CompassText = null;

        [SerializeField]
        private TextMeshProUGUI GoldText = null;

        [SerializeField]
        private TextMeshProUGUI LevelText = null;

        [SerializeField]
        private TextMeshProUGUI HealthText = null;
    #endregion

    #region Variables
    private List<AudioClip> PlayerSounds = new List<AudioClip>();
    #endregion

    void Start()
    {
        //Setup
        _game = Game.Load(gameTextAsset.text);
        CurrentRegionText.text = string.Empty;
        CurrentLocationText.text = string.Empty;
        CharacterNameText.text = string.Empty;
        ScoreText.text = string.Empty;
        CompassText.text = string.Empty;
        GoldText.text = string.Empty;
        LevelText.text = string.Empty;
        HealthText.text = string.Empty;

        //Events
        _game.Player.RegionChanged += PlayerRegionChanged;
        _game.Player.LocationChanged += PlayerLocationChanged;
        _game.Player.NameChanged += PlayerNameChanged;
        _game.Player.GenderChanged += PlayerGenderChanged;
        _game.Player.ScoreChanged += PlayerScoreChanged;
        _game.Player.CompassChanged += CompassChanged;
        _game.Player.LevelChanged += PlayerLevelChanged;
        _game.Player.GoldChanged += PlayerGoldChanged;
        _game.Player.HealthChanged += PlayerHealthChanged;
        _game.GameInit += Game_Init;
        _game.GameQuit += Game_Quit;


        //Testing
        _game.Player.ReceiveDamage += PlayerTakeDamage;


        //Start
        _game.Start(InputService, OutputService);
        OutputService.WriteLine("Press any key to begin!");
        InputService.SelectInputField();
    }

    private void PlayerGenderChanged(object sender, Gender? gender)
    {
        PlayerSounds.Clear();
        switch(gender)
        {
            case Gender.MALE:
                foreach (AudioClip clip in Audio.Male_Sounds)
                    PlayerSounds.Add(clip);
                break;

            case Gender.FEMALE:
                foreach(AudioClip clip in Audio.Female_Sounds)
                    PlayerSounds.Add(clip);
                break;
        }
    }

    private void Game_Init(object sender, EventArgs e)
    {
        OutputService.WriteLine(string.IsNullOrWhiteSpace(_game.WelcomeMessage) ? "Welcome To Vion!" : _game.WelcomeMessage);

        CurrentRegionText.text = _game.Player.Region;
        CurrentLocationText.text = _game.Player.Location.Name;
        
        ScoreText.text = "Score: " + _game.Player.Score.ToString();
        CompassText.text = _game.Player.Compass;

        CharacterNameText.text = _game.Player.PlayerName;
        GoldText.text = _game.Player.Gold.ToString() + " g";
        LevelText.text = "lvl. " + _game.Player.Level.ToString();

        HealthText.text = _game.Player.Health + " HP";

        _game.Look(_game);
    }

    private void Game_Quit(object sender, EventArgs e)
    {
        OutputService.WriteLine(string.IsNullOrWhiteSpace(_game.ExitMessage) ? "Thank you for playing!" : _game.ExitMessage);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void PlayerRegionChanged(object sender, string newRegion)
    {
        CurrentRegionText.text = newRegion.ToString();
    }

    private void PlayerLocationChanged(object sender, Location newLocation)
    {
        CurrentLocationText.text = newLocation.ToString();
        _game.Look(_game);
    }
    private void CompassChanged(object sender, string newHeading)
    {
        CompassText.text = newHeading;
    }

    private void PlayerScoreChanged(object sender, int newScore)
    {
        ScoreText.text = "Score: " + newScore.ToString();
    }

    private void PlayerNameChanged(object sender, string newName)
    {
        CharacterNameText.text = newName.ToString();
    }

    private void PlayerGoldChanged(object sender, int newGold)
    {
        LevelText.text = newGold.ToString() + " g";
    }
    
    private void PlayerLevelChanged(object sender, int newLevel)
    {
        LevelText.text = "lvl. " + newLevel.ToString();
    }

    private void PlayerHealthChanged(object sender, int newHealth)
    {
        HealthText.text = newHealth.ToString() + " HP";
    }

    private void PlayerTakeDamage(object sender, int amount)
    {
        Audio.audioSource.clip = PlayerSounds[Random.Range(0, PlayerSounds.Count)];
        Audio.audioSource.Play();
    }

    private Game _game;
}