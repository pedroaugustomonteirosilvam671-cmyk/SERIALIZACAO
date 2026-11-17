using System.IO;
using System.Text;
using System.Xml.Serialization;
using SerializacaoIndustrial.Models;

namespace SerializacaoIndustrial.Services;

public class RelatorioService
{
    private readonly XmlSerializer _serializer = new(typeof(RelatorioAnalise));

    public void SalvarXml(RelatorioAnalise relatorio, string caminhoArquivo)
    {
        using var writer = new StreamWriter(caminhoArquivo, false, Encoding.UTF8);
        _serializer.Serialize(writer, relatorio);
    }

    public RelatorioAnalise? CarregarXml(string caminhoArquivo)
    {
        using var reader = new StreamReader(caminhoArquivo, Encoding.UTF8);
        return (RelatorioAnalise?)_serializer.Deserialize(reader);
    }
}