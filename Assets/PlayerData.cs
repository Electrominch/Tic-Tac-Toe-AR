using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Threading.Tasks;
using UnityEngine;

public static class PlayerData
{
    public static Settings Settings
    {
        get => _settings;
        set
        {
            _settings = value;
            Save();
        }
    }
    public static Stat EasyBot 
    {
        get => _easyBot;
        set
        {
            _easyBot = value;
            Save();
        }
    }
    public static Stat NormBot 
    {
        get => _normBot;
        set
        {
            _normBot = value;
            Save();
        }
    }
    public static Stat HardBot 
    {
        get => _hardBot;
        set
        {
            _hardBot = value;
            Save();
        }
    }
    
    private static Settings _settings;
    private static Stat _easyBot;
    private static Stat _normBot;
    private static Stat _hardBot;

    static PlayerData()
    {
        Load();
    }

    private static void Save()
    {
        PlayerPrefs.SetString("easyStat", _easyBot.XmlSerializeToString());
        PlayerPrefs.SetString("normalStat", _normBot.XmlSerializeToString());
        PlayerPrefs.SetString("hardStat", _hardBot.XmlSerializeToString());
        PlayerPrefs.SetString("settings", Settings.XmlSerializeToString());
        PlayerPrefs.Save();
    }

    private static void Load()
    {
        try
        {
            string eB = PlayerPrefs.GetString("easyStat");
            _easyBot = eB.XmlDeserializeFromString<Stat>();

            string nB = PlayerPrefs.GetString("normalStat");
            _normBot = nB.XmlDeserializeFromString<Stat>();

            string hB = PlayerPrefs.GetString("hardStat");
            _hardBot = hB.XmlDeserializeFromString<Stat>();

            string sets = PlayerPrefs.GetString("settings");
            _settings = sets.XmlDeserializeFromString<Settings>();
        }
        catch
        {
            SetDefaults();
            Save();
        }
    }

    public static void Reset()
    {
        PlayerPrefs.DeleteAll();
        Load();
    }

    public static void NextDateFormat()
    {
        string[] formats = new string[] { "dd.MM.yyyy", "yyyy-MM-dd","yyyy/MM/dd",  @"yyyy.MM.dd", "MM-dd-yyyy", "MM/dd/yyyy", @"MM.dd.yyyy", @"dd-MM-yyyy", "dd/MM/yyyy" };
        int i = 0;
        for (; i < formats.Length; i++)
            if (formats[i] == Settings.DateFormat)
                break;
        i++;
        if (i >= formats.Length)
            i = 0;
        _settings.DateFormat = formats[i];
        Save();
    }
    
    public static void NextTimeFormat()
    {
        string[] formats = new string[] { "HH:mm", "HH.mm" };
        int i = 0;
        for (; i < formats.Length; i++)
            if (formats[i] == Settings.TimeFormat)
                break;
        i++;
        if (i >= formats.Length)
            i = 0;
        _settings.TimeFormat = formats[i];
        Save();
    }

    private static void SetDefaults()
    {
        _easyBot = new Stat();
        _normBot = new Stat();
        _hardBot = new Stat();
        _settings.Music = true;
        _settings.Sound = true;
        _settings.DateFormat = "dd.MM.yyyy";
        _settings.TimeFormat = "HH:mm";
    }
}

public struct Stat
{
    public int Wins;
    public int Loses;
    public int Draws;
}

public struct Settings
{
    public bool Music;
    public bool Sound;
    public string DateFormat;
    public string TimeFormat;
}