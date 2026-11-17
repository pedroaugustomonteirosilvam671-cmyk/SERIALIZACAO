using System.IO;
using System.Text;
using System.Text.Json;
using SerializacaoIndustrial.Models;

namespace SerializacaoIndustrial.Services;

public class DroneService
{
    private readonly JsonSerializerOptions _opcoes = new() { WriteIndented = true };

    public void SalvarJson(DroneStatus drone, string caminhoArquivo)
    {
        string json = JsonSerializer.Serialize(drone, _opcoes);
        File.WriteAllText(caminhoArquivo, json, Encoding.UTF8);
    }

    public DroneStatus? CarregarJson(string caminhoArquivo)
    {
        string json = File.ReadAllText(caminhoArquivo, Encoding.UTF8);
        return JsonSerializer.Deserialize<DroneStatus>(json);
    }
}
