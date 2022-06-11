namespace Leopotam.Ecs.Menu.UI.Components
{
    internal struct BeginUINavigateComponent
    {
        public string PartName;
        public float Delay;

        public BeginUINavigateComponent(string _partName = "MainMenu", float _delay = -1)
        {
            PartName = _partName;
            Delay = _delay;
        }
    }
}
