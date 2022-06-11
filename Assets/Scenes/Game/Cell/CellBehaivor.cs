using Leopotam.Ecs.Game.Components;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

namespace Leopotam.Ecs.Game.UI
{
    public class CellBehaivor : MonoBehaviour
    {
        public int X;
        public int Y;
        [SerializeField] private Sprite[] Contents;
        [SerializeField] private Image _contentImage;
        [SerializeField] private Image _borderImage;
        [SerializeField] private Image _backImage;
        [SerializeField] private Button _button;
        private int _curCoutent = -1;

        void Start()
        {
            _button = GetComponent<Button>();

        }

        public void SetContent(int contentIndex)
        {
            if (_curCoutent == contentIndex)
                return;
            if (contentIndex >= 0)
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
            _curCoutent = contentIndex;
        }

        public void SetColors(Color back, Color border, Color content)
        {
            _backImage.color = back;
            //_borderImage.color = border;
            //_contentImage.color = content;
        }

        public void CellPressedByUser()
        {
            WorldHandler.GetWorld().SendMessage(new UserGameMoveComponent(X, Y));
        }
    }

}