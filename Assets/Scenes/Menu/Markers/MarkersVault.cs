using Leopotam.Ecs.Ui.Components;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Voody.UniLeo;

public static class MarkersVault
{
    private static readonly string SaveDir = Application.persistentDataPath;
    private static readonly string MarkersDir = Path.Combine(SaveDir, "Markers");
    private static string PathForSave 
    {  
        get
        {
            int i = 0;
            string path = "";
            do
                path = Path.Combine(MarkersDir, $"img{i++}.png");
            while (File.Exists(path));
            return path;
        }
    }

    static MarkersVault()
    {
        Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Markers"));
    }

    public static void AskNew()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                Texture2D tex = new Texture2D(1, 1);
                var res = tex.LoadImage(File.ReadAllBytes(path));
                Debug.Log(res?"Loaded":"Failed");
                if (!res)
                    return;
                File.WriteAllBytes(PathForSave, tex.EncodeToPNG());
                WorldHandler.GetWorld().SendMessage(new UpdateMarkersEventComponent());
            }
        });

        Debug.Log("Permission result: " + permission);
    }

    public static Dictionary<string, Sprite> LoadMarkers()
    {
        Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
        DirectoryInfo di = new DirectoryInfo(MarkersDir);
        foreach (var fi in di.GetFiles())
        {
            try
            {
                Texture2D tex = new Texture2D(1, 1);
                tex.LoadImage(File.ReadAllBytes(fi.FullName));
                sprites.Add(fi.Name, Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero));
            }
            catch { }
        }
        return sprites;
    }

    public static bool Remove(string name)
    {
        if(File.Exists(Path.Combine(MarkersDir, name)))
        {
            File.Delete(Path.Combine(MarkersDir, name));
            return true;
        }
        return false;
    }
}
