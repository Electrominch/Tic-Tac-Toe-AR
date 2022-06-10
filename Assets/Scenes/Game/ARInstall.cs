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

    void AddImage(Texture2D imageToAdd)
    {
        RuntimeReferenceImageLibrary runtimeLibrary = m_TrackedImageManager.CreateRuntimeLibrary();
        var mutable = runtimeLibrary as MutableRuntimeReferenceImageLibrary;
        mutable.ScheduleAddImageWithValidationJob(imageToAdd, "userImg", 1f);
        m_TrackedImageManager.referenceLibrary = mutable;
    }
}
