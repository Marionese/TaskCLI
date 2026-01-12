class TaskItem
{
    public int Id { get; set; }
    public int InternalId { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}