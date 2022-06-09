using Leopotam.Ecs.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal static class Bridge
{
    public static Leopotam.Ecs.Game.Components.PlayMode PlayMode { get; set; }
    public static Bot BotDifficulty { get; set; }
    public static Texture2D Marker { get; set; }
}