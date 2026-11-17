using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializacaoIndustrial.Models;

[XmlRoot("relatorioAnalise")]
public class RelatorioAnalise
{
    [XmlElement("amostra")]
    public Amostra Amostra { get; set; } = new();

    [XmlElement("responsavel")]
    public ResponsavelTecnico Responsavel { get; set; } = new();

    [XmlArray("resultados")]
    [XmlArrayItem("componente")]
    public List<string> Resultados { get; set; } = new();
}

public class Amostra
{
    [XmlElement("idAmostra")]
    public string IdAmostra { get; set; } = string.Empty;

    [XmlElement("tipoMaterial")]
    public string TipoMaterial { get; set; } = string.Empty;

    [XmlElement("dataColeta")]
    public string DataColeta { get; set; } = string.Empty;
}

public class ResponsavelTecnico
{
    [XmlElement("nomeCientista")]
    public string NomeCientista { get; set; } = string.Empty;

    [XmlElement("registroProfissional")]
    public string RegistroProfissional { get; set; } = string.Empty;
}