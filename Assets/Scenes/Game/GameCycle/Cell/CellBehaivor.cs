using Assets.Scenes.Game.GameCycle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

public class CellBehaivor : MonoBehaviour
{
    public int X;
    public int Y;
    [SerializeField] private Sprite[] Contents;
    [SerializeField] private Image _contentImage;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    public void SetContent(int contentIndex)
    {
        if(contentIndex >= 0)
        {
            _button.enabled = false;
            _contentImage.sprite = Contents[contentIndex];
            _contentImage.enabled = true;
        }
        else
        {
            _button.enabled = true;
            _contentImage.enabled = false;
        }
    }

    public void CellPressedByUser()
    {
        WorldHandler.GetWorld().SendMessage(new GameMoveComponent(X,Y));
    }
}
