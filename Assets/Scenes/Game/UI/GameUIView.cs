using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Game.UI
{
    public class GameUIView : MonoBehaviour, ISceneUIView
    {
        public Button BackToMenuButton;
        public Blackout BlackoutService;
        public Blackout GetBlackout() => BlackoutService;

        private void Start()
        {
            BlackoutService.gameObject.SetActive(true);
            BlackoutService.StartBlackoutCycle(() => { });
        }
    }

}