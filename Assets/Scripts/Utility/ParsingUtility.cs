using System.Collections.Generic;

public static class ParsingUtility
{
    private const string beginningSeparator = "# ===============================================================";
    private const string itemSeparator = "\r\n";
    private const string attributeSeparator = " ";

    public static bool CheckFileStringFormat(string data, out string resultMessage)
    {
        string[] strings;
        resultMessage = string.Empty;

        try
        {
            strings = GetAttributeStrings(data);
        }
        catch
        {
            resultMessage = "Неверный формат файла";
            return false;
        }

        foreach (string s in strings)
        {
            string[] attributes = s.Split(attributeSeparator, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string a in attributes)
            {
                if (!float.TryParse(a, out float result))
                {
                    resultMessage = "Неверный формат файла";
                    return false;
                }
            }
        }
        return true;
    }

    public static List<AerosolParticle> ParceFromString(string data)
    {
        string[] strings = GetAttributeStrings(data);

        List<AerosolParticle> particles = new List<AerosolParticle>();

        foreach (string s in strings)
        {
            string[] attributes = s.Split(attributeSeparator, System.StringSplitOptions.RemoveEmptyEntries);

            AerosolParticle particle = new AerosolParticle();
            particle.Ns = float.Parse(attributes[0]);
            particle.Nt = float.Parse(attributes[1]);
            particle.a = float.Parse(attributes[2]);
            particle.X = float.Parse(attributes[3]);
            particle.Y = float.Parse(attributes[4]);
            particle.Z = float.Parse(attributes[5]);
            particle.radius = float.Parse(attributes[6]);
            particles.Add(particle);
        }

        return particles;
    }

    private static string[] GetAttributeStrings(string data)
    {
        string[] strings = data.Split(beginningSeparator, System.StringSplitOptions.RemoveEmptyEntries);
        data = strings[strings.Length - 1];
        return data.Split(itemSeparator, System.StringSplitOptions.RemoveEmptyEntries);
    }
}
