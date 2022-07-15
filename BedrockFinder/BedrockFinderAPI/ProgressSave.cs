using static Newtonsoft.Json.JsonConvert;
public class ProgressSave
{
    public ProgressSave(BedrockSearch searcher)
    {
        Range = searcher.Range;
        Progress = searcher.Progress;
        Result = searcher.Result;
        Pattern = searcher.Pattern;
        Path = searcher.PathToSave;
    }
    public string Path;
    public SearchRange Range;
    public SearchProgress Progress;
    public List<Vec2i> Result;
    public BedrockPattern Pattern;
    public void Save() => Save(Path);
    public void Save(string path) => File.WriteAllBytes(path, System.Text.Encoding.UTF8.GetBytes(SerializeObject(this)));
    public static ProgressSave Load(string path) => (ProgressSave)DeserializeObject(System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(path)));
}