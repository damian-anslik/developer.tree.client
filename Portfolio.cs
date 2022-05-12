namespace ApiClient.Models;

class Portfolio
{
    public int portfolioId { get; set; }
    public string OwnerId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description{ get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public List<Project> Projects { get; set; }
}