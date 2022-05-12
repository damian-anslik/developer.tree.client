namespace ApiClient.Models;

class Project
{
    public int ProjectId { get; set; }
    public string OwnerId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? SourceUrl { get; set; }
    public string? DemoUrl { get; set; }
}