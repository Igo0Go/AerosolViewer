using System.Collections.Generic;
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
            loadStateString.text = result.filePath;
            List<AerosolParticle> particles = ParsingUtility.ParceFromString(result.fileText);

            for (int i = 0; i < particles.Count; i++)
            {
                AerosolParticle particle = particles[i];
                loadedText.text += "Частица " + (i+1) + "\n";
                loadedText.text += "Позиция: (" + particle.X + "; " + particle.Y + "; " + particle.Z + ")\n";
                loadedText.text += "Радиус = " + particle.radius + "\n";
                loadedText.text += "Ns = " + particle.Ns;
                loadedText.text += "; Nt = " + particle.Nt;
                loadedText.text += "; a = " + particle.a + "\n";
                if(i < particles.Count - 1)
                {
                    loadedText.text += "-----------------\n";
                }
            }
        }
        else
        {
            loadErrorStateString.text = result.errorText;
        }
    }
}
