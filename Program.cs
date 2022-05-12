using ApiClient.Models;
using System.Text.Json;

namespace ApiClient;
public class Program
{
    public static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        var portfolios = await GetPortfolios(client, "https://developer-tree.azurewebsites.net/api/portfolios", 2);
        var projects = await GetProjects(client, "https://developer-tree.azurewebsites.net/api/projects", 1);
        Console.WriteLine("Portfolios:");
        foreach (Portfolio portfolio in portfolios)
        {
            Console.WriteLine($"{portfolio.Title}");
        }
        Console.WriteLine("Projects:");
        foreach (Project project in projects)
        {
            Console.WriteLine($"{project.Title}");
        }
    }

    private static async Task<List<Portfolio>> GetPortfolios(HttpClient client, string url, int? numPortfolios = null)
    {
        if (numPortfolios is not null)
        {
            url += String.Format("?numPortfolios={0}", (int)numPortfolios);
        }
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        var portfolios = JsonSerializer.Deserialize<List<Portfolio>>(
            content, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        return portfolios;
    }

    private static async Task<List<Project>> GetProjects(HttpClient client, string url, int? numProjects = null)
    {
        if (numProjects is not null)
        {
            url += String.Format("?numProjects={0}", numProjects);
        }
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        var projects = JsonSerializer.Deserialize<List<Project>>(
            content, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        return projects;
    }
}