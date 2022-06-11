using TMPro;
using UnityEngine;

public class StatsUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _easy;
    [SerializeField] private TextMeshProUGUI _norm;
    [SerializeField] private TextMeshProUGUI _hard;
    // Start is called before the first frame update
    void Start()
    {
        _easy.text = StatToString(PlayerData.EasyBot);
        _norm.text = StatToString(PlayerData.NormBot);
        _hard.text = StatToString(PlayerData.HardBot);
    }

    private string StatToString(Stat stat)
    {
        return $"{stat.Wins}\t\n\n{stat.Loses}\t\n\n{stat.Draws}\t";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
