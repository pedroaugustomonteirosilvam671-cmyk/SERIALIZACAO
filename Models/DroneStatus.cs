namespace SerializacaoIndustrial.Models;

public class DroneStatus
{
    public string CodigoIdentificador { get; set; } = string.Empty;
    public int NivelBateria { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool EmMissao { get; set; }
}