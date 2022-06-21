using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInstall : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager m_TrackedImageManager;
    [SerializeField] private Camera _ARCamera;
    [SerializeField] private NotFoundOverlay _overlay;
    [SerializeField] float stepScale = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        AddImage(Bridge.Marker);
        _overlay.TargetImage.sprite = Bridge.Marker.ToSprite();
        _overlay.TargetImage.type = Image.Type.Sliced;
        _overlay.gameObject.SetActive(true);
        m_TrackedImageManager.trackedImagesChanged += args =>
        {
            foreach (var a in args.added)
            {
                a.gameObject.GetComponentInChildren<Canvas>().worldCamera = _ARCamera;
            }
            foreach(var a in args.removed)
            {
            }
            foreach(var updated in args.updated)
            {
                if(updated.trackingState == TrackingState.None || updated.trackingState == TrackingState.Limited)
                {
                    updated.gameObject.SetActive(false);
                    _overlay.gameObject.SetActive(true);
                }
                else
                {
                    updated.gameObject.SetActive(true);
                    _overlay.gameObject.SetActive(false);
                }
            }
        };

    }

    public void PlusScale()
    {
        foreach (var a in m_TrackedImageManager.trackables)
            a.gameObject.transform.localScale += new Vector3(stepScale, stepScale, stepScale);
    }

    public void MinusScale()
    {
        foreach (var a in m_TrackedImageManager.trackables)
            if(a.gameObject.transform.lossyScale.x > stepScale)
                a.gameObject.transform.localScale -= new Vector3(stepScale, stepScale, stepScale);
    }

    void AddImage(Texture2D imageToAdd)
    {
        RuntimeReferenceImageLibrary runtimeLibrary = m_TrackedImageManager.CreateRuntimeLibrary();
        var mutable = runtimeLibrary as MutableRuntimeReferenceImageLibrary;
        mutable.ScheduleAddImageWithValidationJob(imageToAdd, "userImg", 1f);
        m_TrackedImageManager.referenceLibrary = mutable;
    }
}
