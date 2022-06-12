using Leopotam.Ecs.Game.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotView : MonoBehaviour
{
    [SerializeField] private Sprite[] _avatars;
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _difficulty;

    public void SetBotDif(Bot bot)
    {
        _difficulty.text = bot.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        _avatar.sprite = _avatars[Random.Range(0, _avatars.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
