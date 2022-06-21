using System;
using System.Collections.Generic;
using System.Linq;
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
    public static List<TournamentRes> TournamentRes => _tours.ToList();

    private static Settings _settings;
    private static Stat _easyBot;
    private static Stat _normBot;
    private static Stat _hardBot;
    private static List<TournamentRes> _tours;

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
        PlayerPrefs.SetString("tours", _tours.XmlSerializeToString());
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
            
            string tours = PlayerPrefs.GetString("tours");
            _tours = tours.XmlDeserializeFromString<List<TournamentRes>>();
            if (_tours.Count != 5)
                throw new Exception();
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

    public static void TryAddResult(TournamentRes res)
    {
        for(int i = 0; i < _tours.Count; i++)
        {
            if (_tours[i].Wins < res.Wins)
            {
                _tours[i] = res;
                Save();
                break;
            }
        }
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
        _tours = new List<TournamentRes>();
        while (_tours.Count != 5)
            _tours.Add(new TournamentRes() { DateTime = DateTime.Now.Date });
    }
}

public struct Stat
{
    public int Wins;
    public int Loses;
    public int Draws;

    public static Stat operator+(Stat l, Stat r)
    {
        return new Stat() { Wins = l.Wins + r.Wins, Draws = l.Draws + r.Draws, Loses = l.Loses+r.Loses };
    }
}

public struct Settings
{
    public bool Music;
    public bool Sound;
    public string DateFormat;
    public string TimeFormat;
}

public struct TournamentRes
{
    public int Wins;
    public DateTime DateTime;

    public TournamentRes(int wins, DateTime dt)
    {
        Wins = wins;
        DateTime = dt;
    }
}