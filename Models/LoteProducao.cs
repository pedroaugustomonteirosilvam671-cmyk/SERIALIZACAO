namespace SerializacaoIndustrial.Models;

public class LoteProducao
{
    public int NumeroLote { get; set; }
    public string TipoLiga { get; set; } = string.Empty;
    public decimal PesoTotal { get; set; }
    public decimal TemperaturaFundicao { get; set; }
    public string StatusQualidade { get; set; } = string.Empty;
}