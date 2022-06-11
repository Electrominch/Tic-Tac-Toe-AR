namespace Leopotam.Ecs.Game.Components
{
    internal struct BotComponent
    {
        public Bot BotDif;
        public bool Moving;//делает ли бот ход
        public float TimeForEndMove;//время, когда бот сделает ход
    }

    public enum Bot
    {
        Easy,
        Normal,
        Hard,
        Tournament
    }
}
