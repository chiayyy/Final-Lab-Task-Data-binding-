namespace NotesApp.Models;

public class Note
{
    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public Note()
    {
        Filename = $"{Path.GetRandomFileName()}.notes.txt";
        Date = DateTime.Now;
        Text = "";
    }

    public void Save()
    {
        File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);
    }

    public void Delete()
    {
        if (File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename)))
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));
    }

    public static Note Load(string filename)
    {
        filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

        if (!File.Exists(filename))
            throw new FileNotFoundException("Unable to find file on local storage.", filename);

        return new Note
        {
            Filename = Path.GetFileName(filename),
            Text = File.ReadAllText(filename),
            Date = File.GetLastWriteTime(filename)
        };
    }

    public static IEnumerable<Note> LoadAll()
    {
        var appDataPath = FileSystem.AppDataDirectory;

        var notes = Directory
                    .EnumerateFiles(appDataPath, "*.notes.txt")
                    .Select(filename => Note.Load(Path.GetFileName(filename)))
                    .OrderByDescending(note => note.Date);

        return notes;
    }
}
