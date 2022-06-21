using Leopotam.Ecs.Game.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotView : MonoBehaviour
{
    [SerializeField] private Sprite[] _avatars;
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _difficulty;

    public void SetBotText(string text)
    {
        _difficulty.text = text;
    }

    private int lastIndex = -1;
    public void RandomAvatar()
    {
        int rndIndex = -1;
        do
        {
            rndIndex = Random.Range(0, _avatars.Length);
        }
        while (rndIndex == lastIndex);
        _avatar.sprite = _avatars[rndIndex];
        lastIndex = rndIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
