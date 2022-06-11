using UnityEngine;

namespace Leopotam.Ecs.Menu.UI
{
    public class MainSceneUIView : MonoBehaviour, ISceneUIView
    {
        public MenuUIView MenuPart;
        public SelectBotUIView SelectBotPart;
        public SettingsUIView SettingsPart;
        public SelectMarkerUIView MarkerPart;
        public Blackout BlackoutService;
        public BackRotate Background;

        public Blackout GetBlackout() => BlackoutService;

        private void Start()
        {
            BlackoutService.gameObject.SetActive(true);
            MenuPart.gameObject.SetActive(true);
            SelectBotPart.gameObject.SetActive(true);
            SettingsPart.gameObject.SetActive(true);
            MarkerPart.gameObject.SetActive(true);
        }
    }

}