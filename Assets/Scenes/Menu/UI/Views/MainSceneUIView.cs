using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneUIView : MonoBehaviour
{
    public MenuUIView MenuPart;
    public SelectBotUIView SelectBotPart;
    public SettingsUIView SettingsPart;
    public SelectMarkerUIView MarkerPart;
    public Blackout BlackoutService;
    public BackRotate Background;

    private void Start()
    {
        BlackoutService.gameObject.SetActive(true);
        MenuPart.gameObject.SetActive(true);
        SelectBotPart.gameObject.SetActive(true);
        SettingsPart.gameObject.SetActive(true);
        MarkerPart.gameObject.SetActive(true);
    }
}
