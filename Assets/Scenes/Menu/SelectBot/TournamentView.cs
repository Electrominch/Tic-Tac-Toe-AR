using TMPro;
using UnityEngine;

public class TournamentView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    void OnEnable()
    {
        var ress = PlayerData.TournamentRes;
        var str = "";
        for(int i = 0; i < ress.Count; i++)
        {
            str += $"\t{i + 1})\t{ress[i].Wins}\t{ress[i].DateTime.ToString(PlayerData.Settings.DateFormat)} {ress[i].DateTime.ToString(PlayerData.Settings.TimeFormat)}\n";
        }
        _text.text = str;
    }
}
