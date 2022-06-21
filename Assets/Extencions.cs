using Leopotam.Ecs;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

internal static class Extencions
{
    public static void SendMessage<T>(T mes) where T : struct
    {
        Voody.UniLeo.WorldHandler.GetWorld().NewEntity().Get<T>();
    }
    
    public static void SendMessage<T>(this EcsWorld world, T mes) where T : struct
    {
        world.NewEntity().Get<T>() = mes;
    }

    public static string XmlSerializeToString(this object objectInstance)
    {
        var serializer = new XmlSerializer(objectInstance.GetType());
        var sb = new StringBuilder();

        using (TextWriter writer = new StringWriter(sb))
        {
            serializer.Serialize(writer, objectInstance);
        }

        return sb.ToString();
    }

    public static T XmlDeserializeFromString<T>(this string objectData)
    {
        return (T)XmlDeserializeFromString(objectData, typeof(T));
    }

    public static object XmlDeserializeFromString(this string objectData, Type type)
    {
        var serializer = new XmlSerializer(type);
        object result;

        using (TextReader reader = new StringReader(objectData))
        {
            result = serializer.Deserialize(reader);
        }

        return result;
    }

    public static Sprite ToSprite(this Texture2D tex) => Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);

    public static Color GetRandomColor()
    {
        return UnityEngine.Random.ColorHSV(0,1,0,0.5f,0.5f,1);
    }
}