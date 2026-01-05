using TMPro;
using UnityEngine;

public class LoaderTest : MonoBehaviour
{
    [SerializeField]
    private TMP_Text loadStateString;
    [SerializeField]
    private TMP_Text loadErrorStateString;
    [SerializeField]
    private TMP_Text loadedText;

    private void Start()
    {
        ResetTexts();
    }

    private void ResetTexts()
    {
        loadStateString.text = loadErrorStateString.text = loadedText.text = string.Empty;
    }

    public void TestLoad()
    {
        ResetTexts();
        FileAccessResult result = FileAccessUtility.GetDataFromFile();

        if(result.success)
        {
            loadedText.text = result.fileText;
            loadStateString.text = result.filePath;
        }
        else
        {
            loadErrorStateString.text = result.errorText;
        }
    }
}
