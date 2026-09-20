namespace Direction.Services;

public class TranslationService
{
    private readonly string _languageStorePath = "C:\\Users\\user\\Desktop\\dictionary folder\\translation.txt";

    public void AddTranslation(string source, string target, string languageDirection)
    {
        var translation = $"Source: {source}, Target: {target}, LanguageDirection: {languageDirection}";
        using var writer = new StreamWriter(_languageStorePath, true);
        writer.WriteLine(translation);
    }

    public List<string> GetTranslations(string languageDirection)
    {
        var translations = new List<string>();
        if (File.Exists(_languageStorePath))
        {
            using var reader = new StreamReader(_languageStorePath);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(", ");
                if (parts.Length == 3 && parts[2] == languageDirection)
                {
                    translations.Add($"Source: {parts[0]}, Target: {parts[1]}");
                }
            }
        }

        return translations;
    }

    public string Translate(string source, string languageDirection)
    {
        if (File.Exists(_languageStorePath))
        {
            using var reader = new StreamReader(_languageStorePath);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(", ");

                if (parts.Length == 3 &&
                    parts[0] == $"Source: {source}" &&
                    parts[2] == $"LanguageDirection: {languageDirection}")
                {
                    return parts[1].Replace("Target: ", "");
                }
            }
        }

        return null;
    }

    public bool IsLanguegePartSupported(string languageDirection)
    {
        if (File.Exists(_languageStorePath))
        {
            using var reader = new StreamReader(_languageStorePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(", ");
                if (parts.Length == 3 && parts[2] == languageDirection)
                {
                    return true;
                }
            }
        }
        return false;
    }
}