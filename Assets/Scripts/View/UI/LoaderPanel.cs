using System;
using TMPro;
using UnityEngine;

public class LoaderPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text loadStateString;
    [SerializeField]
    private TMP_Text loadErrorStateString;

    public event Action LoadFileClick;

    private void Start()
    {
        ResetTexts();
    }

    public void OnLoadFinaled(FileAccessResult result)
    {
        ResetTexts();

        if (result.success)
        {
            loadStateString.text = result.filePath;
        }
        else
        {
            loadErrorStateString.text = result.errorText;
        }
    }

    public void OnClick()
    {
        LoadFileClick?.Invoke();
    }

    private void ResetTexts()
    {
        loadStateString.text = loadErrorStateString.text = string.Empty;
    }
}
