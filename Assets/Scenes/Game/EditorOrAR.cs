using UnityEngine;

public class EditorOrAR : MonoBehaviour
{
    [SerializeField] private GameObject _editor;
    [SerializeField] private GameObject _AR;
    // Start is called before the first frame update
    void Awake()
    {
#if UNITY_EDITOR
        _editor.SetActive(true);
        _AR.SetActive(false);
#else
        _editor.SetActive(false);
        _AR.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
