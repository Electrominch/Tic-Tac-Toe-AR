using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Menu.UI
{
    public class SettingsUIView : MonoBehaviour
    {
        public Button BackToMenu;
        public Button Music;
        public Button Sound;
        public Button Reset;
        public Button DateFormat;
        public Button TimeFormat;
        public GameObject _crossForMusic;
        public GameObject _crossForSound;
        [SerializeField] private BackMusic _back;

        private void Start()
        {
            UpdateUI();
            Music.onClick.AddListener(() =>
            {
                var sets = PlayerData.Settings;
                sets.Music = !sets.Music;
                PlayerData.Settings = sets;
                if (sets.Music)
                    _back.StartMusic();
                else
                    _back.StopMusic();
                UpdateUI();
            });
            Sound.onClick.AddListener(() =>
            {
                var sets = PlayerData.Settings;
                sets.Sound = !sets.Sound;
                PlayerData.Settings = sets;
                UpdateUI();
            });
            Reset.onClick.AddListener(() =>
            {
                PlayerData.Reset();
                UpdateUI();
            });
            DateFormat.onClick.AddListener(() =>
            {
                PlayerData.NextDateFormat();
                UpdateUI();
            });
            TimeFormat.onClick.AddListener(() =>
            {
                PlayerData.NextTimeFormat();
                UpdateUI();
            });
        }

        private void UpdateUI()
        {
            var sets = PlayerData.Settings;
            _crossForMusic.SetActive(!sets.Music);
            _crossForSound.SetActive(!sets.Sound);
            DateTime dt = new DateTime(2022, 12, 31, 23, 59, 0);
            DateFormat.GetComponentInChildren<TextMeshProUGUI>().text = dt.ToString(sets.DateFormat, CultureInfo.InvariantCulture);
            TimeFormat.GetComponentInChildren<TextMeshProUGUI>().text = dt.ToString(sets.TimeFormat, CultureInfo.InvariantCulture);
        }
    }

}