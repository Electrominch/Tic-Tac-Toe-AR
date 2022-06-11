using Leopotam.Ecs.Menu.Components;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

namespace Leopotam.Ecs.Menu.UI
{
    public class MarkerButton : MonoBehaviour
    {
        public string MarkerName { get; set; }
        [SerializeField] private Image _imgView;

        public void SetSprite(Sprite sprite)
        {
            _imgView.sprite = sprite;
        }

        public void DeleteThis()
        {
            MarkersVault.Remove(MarkerName);
            Destroy(gameObject);
        }

        public void PlayThis()
        {
            WorldHandler.GetWorld().SendMessage(new StartGameComponent(MarkersVault.LoadMarker(MarkerName)));
        }
    }

}