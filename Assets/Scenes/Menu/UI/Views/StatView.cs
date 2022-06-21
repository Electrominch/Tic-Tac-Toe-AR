using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Menu.UI
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private Image _linkedImage;
        [SerializeField] private Sprite _orig;
        [SerializeField] private Sprite _selected;
        private Color startColor;

        public void Select()
        {
            _linkedImage.sprite = _selected;
            foreach (Transform t in transform)
                t.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            _linkedImage.sprite = _orig;
            foreach (Transform t in transform)
                t.gameObject.SetActive(false);
        }

        // Start is called before the first frame update
        void Start()
        {
            startColor = _linkedImage.color;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}