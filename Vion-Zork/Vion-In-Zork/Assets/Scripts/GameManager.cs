using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
//using Zork;

public class GameManager : MonoBehaviour
{
    #region References
        [Header("Audio")]
        [SerializeField]
        private AudioManager audioManager = null;

        [Header("I/O Services")]
        [SerializeField]
        private VionInputService vionInputService = null;

        [SerializeField]
        private VionOutputService vionOutputService = null;

        [Header("UI Fields")]
        [SerializeField]
        private TextMeshProUGUI currentCityText = null;

        [SerializeField]
        private TextMeshProUGUI currentLocationText = null;

        [SerializeField]
        private TextMeshProUGUI characterNameText = null;

        [SerializeField]
        private TextMeshProUGUI scoreText = null;
    #endregion

    #region Variables
        private List<AudioClip> Player_Sounds = new List<AudioClip>();
    #endregion

    void Start()
    {
        TextAsset gameTextAsset = Resources.Load<TextAsset>("Vion");
        //_game = JsonConvert.DeserializeObject<Game>(gameTextAsset.text);
        //_game.Player.LocationChanged += CurrentLocationChanged;

        //_game.Start(InputService, OutputService);
        //CurrentLocationText.text = _game.Player.Location.ToString();
    }


    //private void CurrentLocationChanged(object sender, Room newLocation)
    //{
    //    currentLocationText.text = newLocation.ToString();
    //}

    //private Game _game;
}