public class StoryTextData
{
    public int Id { get; private set; }
    public string Text { get; private set; }

    public StoryTextData(int id, string text)
    {
        Id = id;
        Text = text;
    }
}
