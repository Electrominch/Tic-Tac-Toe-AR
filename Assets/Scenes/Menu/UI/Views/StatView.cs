using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Menu.UI
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private Image _linkedImage;
        private Color startColor;

        public void Select()
        {
            _linkedImage.color = Color.red;
            foreach (Transform t in transform)
                t.gameObject.SetActive(true);
        }

        public void Unselect()
        {
            foreach (Transform t in transform)
                t.gameObject.SetActive(false);
            _linkedImage.color = startColor;
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