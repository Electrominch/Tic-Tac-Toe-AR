using Leopotam.Ecs.Game;
using Leopotam.Ecs.Game.Components;
using UnityEngine;

internal static class Bridge
{
    public static TicTacMode PlayMode { get; set; }
    public static Bot BotDifficulty { get; set; }
    public static Texture2D Marker { get; set; }
}