using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _wins;
    [SerializeField] private TextMeshProUGUI _loses;
    [SerializeField] private TextMeshProUGUI _draws;

    public void UpdateStats(Stat s)
    {
        _wins.text = s.Wins.ToString();
        _loses.text = s.Loses.ToString();
        _draws.text = s.Draws.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
