using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SerializacaoIndustrial.Models;

namespace SerializacaoIndustrial.Services;

public class LoteProducaoService
{
    public void SalvarCsv(List<LoteProducao> lotes, string caminhoArquivo)
    {
        var linhas = new List<string>
        {
            "numeroLote;tipoLiga;pesoTotal;temperaturaFundicao;statusQualidade"
        };

        foreach (var lote in lotes)
        {
            linhas.Add(string.Join(";",
                lote.NumeroLote,
                lote.TipoLiga,
                lote.PesoTotal.ToString(CultureInfo.InvariantCulture),
                lote.TemperaturaFundicao.ToString(CultureInfo.InvariantCulture),
                lote.StatusQualidade
            ));
        }

        File.WriteAllLines(caminhoArquivo, linhas, Encoding.UTF8);
    }

    public List<LoteProducao> CarregarCsv(string caminhoArquivo)
    {
        var lotes = new List<LoteProducao>();
        string[] linhas = File.ReadAllLines(caminhoArquivo, Encoding.UTF8);

        foreach (string linha in linhas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linha)) continue;

            string[] colunas = linha.Split(';');
            lotes.Add(new LoteProducao
            {
                NumeroLote = int.Parse(colunas[0]),
                TipoLiga = colunas[1],
                PesoTotal = decimal.Parse(colunas[2], CultureInfo.InvariantCulture),
                TemperaturaFundicao = decimal.Parse(colunas[3], CultureInfo.InvariantCulture),
                StatusQualidade = colunas[4]
            });
        }

        return lotes;
    }

    public decimal CalcularMediaTemperatura(List<LoteProducao> lotes)
    {
        return lotes.Count > 0 ? lotes.Average(l => l.TemperaturaFundicao) : 0m;
    }
}