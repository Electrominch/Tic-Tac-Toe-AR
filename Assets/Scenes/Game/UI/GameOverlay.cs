using Leopotam.Ecs.Game.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] private TextWithBack _mid;
    [SerializeField] private TextWithBack _p1;
    [SerializeField] private TextWithBack _p2;
    [SerializeField] private GameObject _rayCastPanel;
    public bool LastDraw = false;
    private Action _callback;

    public void Clicked()
    {
        _rayCastPanel.SetActive(false);
        _callback?.Invoke();
        _mid.Hide();
        _p1.Hide();
        _p2.Hide();
    }

    public void SetRayCastBlock(Action callback)
    {
        _rayCastPanel.SetActive(true);
        _callback = callback;
    }
    
    public void SetPlayer1(string s, Color c) => _p1.Show(s, c);
    public void SetPlayer2(string s, Color c) => _p2.Show(s, c);
    public void SetMid(string s, Color c) => _mid.Show(s, c);

    // Start is called before the first frame update
    void Start()
    {
        _mid.Hide();
        _p1.Hide();
        _p2.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
