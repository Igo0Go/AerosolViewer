using UnityEngine;

public class LoaderTest : MonoBehaviour
{
    public void TestLoad()
    {
        Debug.Log(FileAccessUtility.GetDataFromFile());
    }
}
