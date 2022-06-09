using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInstall : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager m_TrackedImageManager;
    [SerializeField] private Image _target;

    // Start is called before the first frame update
    void Start()
    {
        
        AddImage(Bridge.Marker);
    }

    AddReferenceImageJobState stat;
    void AddImage(Texture2D imageToAdd)
    {
        RuntimeReferenceImageLibrary runtimeLibrary = m_TrackedImageManager.CreateRuntimeLibrary();
        var mutable = runtimeLibrary as MutableRuntimeReferenceImageLibrary;
        stat = mutable.ScheduleAddImageWithValidationJob(imageToAdd, "userImg", 1f);
        m_TrackedImageManager.referenceLibrary = mutable;
    }

    public void PrintStat()
    {
        Debug.Log($"{stat} {m_TrackedImageManager.referenceLibrary.count}");
        for(int i = 0; i < m_TrackedImageManager.referenceLibrary.count; i++)
        {
            var t = m_TrackedImageManager.referenceLibrary[i];
            Debug.Log($"{t.size} {t.specifySize}");
        }
        var last = m_TrackedImageManager.referenceLibrary[m_TrackedImageManager.referenceLibrary.count - 1].texture;
        _target.sprite = Sprite.Create(last, new Rect(0, 0, last.width, last.height), Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
