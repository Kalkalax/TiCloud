using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using TiCloud_Desktop.core.data.models;

namespace TiCloud_Desktop.core.data
{
    public static class UpdateInfoManager
    {

        public static readonly string UpdatesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "updates");

        private static readonly Regex versionRegex = new Regex(@"update_(\d+)_(\d+)_(\d+)\.json$", RegexOptions.Compiled);

        public static bool FolderExists()
        {
            return Directory.Exists(UpdatesFolderPath);
        }

        public static int CountUpdateFiles()
        {
            // Sprawdzenie, czy folder istnieje
            if (!FolderExists())
            {
                Debug.WriteLine("Folder z aktualizacjami nie istnieje.");
                return 0;
            }

            // Pobranie wszystkich plików z folderu, które zaczynają się na "update" i mają rozszerzenie .json
            string[] updateFiles = Directory.GetFiles(UpdatesFolderPath, "update_*.json");
            

            // Zwrócenie liczby tych plików
            return updateFiles.Length;
        }

        public static List<UpdateData> LoadAllUpdates()
        {
            List<UpdateData> updates = new List<UpdateData>();

            if (!FolderExists())
            {
                Debug.WriteLine("Folder z aktualizacjami nie istnieje.");
                return updates;
            }

            // Pobranie wszystkich plików update_X_Y_Z.json
            string[] updateFiles = Directory.GetFiles(UpdatesFolderPath, "update_*.json");

            // Parsowanie numeru wersji i sortowanie (od najwyższej do najniższej)
            var sortedFiles = updateFiles
                .Select(file => new
                {
                    FilePath = file,
                    Match = versionRegex.Match(Path.GetFileName(file))
                })
                .Where(x => x.Match.Success) // Filtrujemy tylko poprawne nazwy
                .Select(x => new
                {
                    x.FilePath,
                    Major = int.Parse(x.Match.Groups[1].Value),
                    Minor = int.Parse(x.Match.Groups[2].Value),
                    Patch = int.Parse(x.Match.Groups[3].Value)
                })
                .OrderByDescending(x => x.Major)
                .ThenByDescending(x => x.Minor)
                .ThenByDescending(x => x.Patch)
                .Select(x => x.FilePath)
                .ToList();

            // Wczytanie zawartości plików do listy
            foreach (var file in sortedFiles)
            {
                try
                {
                    string jsonContent = File.ReadAllText(file);
                    UpdateData update = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateData>(jsonContent);

                    if (update != null)
                        updates.Add(update);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Błąd podczas odczytu pliku {file}: {ex.Message}");
                }
            }

            return updates;
        }


    }

}
