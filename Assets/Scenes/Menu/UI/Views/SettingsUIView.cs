using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIView : MonoBehaviour
{
    public Button BackToMenu;
    public Button Music;
    public Button Sound;
    public Button Reset;
    public Button DateFormat;
    public Button TimeFormat;

    private void Start()
    {
        UpdateUI();
        Music.onClick.AddListener(() => 
        {
            var sets = PlayerData.Settings;
            sets.Music = !sets.Music;
            PlayerData.Settings = sets;
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
    }

    private void UpdateUI()
    {
        var sets = PlayerData.Settings;
        Music.image.color = sets.Music ? Color.green : Color.red;
        Sound.image.color = sets.Sound ? Color.green : Color.red;
        DateFormat.GetComponentInChildren<TextMeshProUGUI>().text = sets.DateFormat;
        TimeFormat.GetComponentInChildren<TextMeshProUGUI>().text = sets.TimeFormat;
    }
}
