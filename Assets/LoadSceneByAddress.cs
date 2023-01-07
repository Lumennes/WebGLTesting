using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

internal class LoadSceneByAddress : MonoBehaviour
{
    public static LoadSceneByAddress Instance { get; private set; }

    public string key; // address string
    private AsyncOperationHandle<SceneInstance> loadHandle;
    [SerializeField] TMP_Text loadText;
    [SerializeField] Canvas loadCanvas;
    bool loading;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Application.targetFrameRate = Application.platform == RuntimePlatform.Android ? 60 : -1;
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            QualitySettings.vSyncCount = 0;
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;

        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(loadCanvas);
    }

    private void Start()
    {
        //SetCursor(false, CursorLockMode.Locked);
        LoadScene(key);
    }

    public void LoadScene(string key)
    {
        StartCoroutine(LoadSceneAsync(key));
    }

    //private void OnApplicationFocus(bool hasFocus)
    //{
    //    SetCursor(false, CursorLockMode.Locked);
    //}

    //public void SetCursor(bool visible = true, CursorLockMode cursorLockMode = CursorLockMode.None)
    //{
    //    Cursor.visible = visible;
    //    Cursor.lockState = cursorLockMode;
    //}

    IEnumerator LoadSceneAsync(string key)
    {
        loadCanvas.enabled = true;
        loading = true;

        loadHandle = Addressables.LoadSceneAsync(key, LoadSceneMode.Single, false);

        yield return loadHandle;

        //One way to handle manual scene activation.
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            loading = false;
            if (loadText)
                loadText.text = $"Загрузка: 100%";
            yield return loadHandle.Result.ActivateAsync();
            loadCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (loading && loadText)
            loadText.text = $"Загрузка: {(int)(loadHandle.PercentComplete * 100)}%";
    }

    //void OnDestroy()
    //{
    //    Addressables.UnloadSceneAsync(loadHandle);
    //}
}
