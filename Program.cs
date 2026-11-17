using System;
using System.Collections.Generic;
using SerializacaoIndustrial.Models;
using SerializacaoIndustrial.Services;

// --- ATIVIDADE 1: JSON ---
Console.WriteLine("=== ATIVIDADE 1: TECHLOGISTICS S.A. (JSON) ===");
var droneService = new DroneService();
var drone = new DroneStatus
{
    CodigoIdentificador = "DRN-TL-042",
    NivelBateria = 87,
    Latitude = -19.9321m,
    Longitude = -44.0539m,
    EmMissao = true
};

droneService.SalvarJson(drone, "status_drone.json");
var droneLido = droneService.CarregarJson("status_drone.json");

if (droneLido != null)
{
    Console.WriteLine($"Drone: {droneLido.CodigoIdentificador} | Bateria: {droneLido.NivelBateria}% | Em Missão: {droneLido.EmMissao}\n");
}

// --- ATIVIDADE 2: XML ---
Console.WriteLine("=== ATIVIDADE 2: BIOGENETICS LAB (XML) ===");
var relatorioService = new RelatorioService();
var relatorio = new RelatorioAnalise
{
    Amostra = new Amostra
    {
        IdAmostra = "BIO-2026-9981",
        TipoMaterial = "Tecido Epitelial Criopreservado",
        DataColeta = "2026-11-17"
    },
    Responsavel = new ResponsavelTecnico
    {
        NomeCientista = "Dra. Helena Vasconcelos",
        RegistroProfissional = "CRBio-04/88412-D"
    },
    Resultados = new List<string>
    {
        "Proteína p53 Recombinante",
        "Enzima Polimerase Taq",
        "Marcador Fluorescente GFP"
    }
};

relatorioService.SalvarXml(relatorio, "relatorio_amostra.xml");
var relatorioLido = relatorioService.CarregarXml("relatorio_amostra.xml");

if (relatorioLido != null)
{
    Console.WriteLine($"Amostra: {relatorioLido.Amostra.IdAmostra} | Responsável: {relatorioLido.Responsavel.NomeCientista}");
    Console.WriteLine($"Componentes: {string.Join(", ", relatorioLido.Resultados)}\n");
}

// --- ATIVIDADE 3: CSV ---
Console.WriteLine("=== ATIVIDADE 3: STEELFORGE INDÚSTRIA (CSV) ===");
var loteService = new LoteProducaoService();
var lotesTurno = new List<LoteProducao>
{
    new() { NumeroLote = 1001, TipoLiga = "Aço Inox 316L", PesoTotal = 4500.50m, TemperaturaFundicao = 1420.0m, StatusQualidade = "Aprovado" },
    new() { NumeroLote = 1002, TipoLiga = "Titânio Grau 5", PesoTotal = 1200.00m, TemperaturaFundicao = 1660.5m, StatusQualidade = "Aprovado" },
    new() { NumeroLote = 1003, TipoLiga = "Aço Carbono 1045", PesoTotal = 6800.75m, TemperaturaFundicao = 1510.2m, StatusQualidade = "Em Análise" },
    new() { NumeroLote = 1004, TipoLiga = "Liga de Níquel Inconel", PesoTotal = 980.30m, TemperaturaFundicao = 1395.8m, StatusQualidade = "Aprovado" },
    new() { NumeroLote = 1005, TipoLiga = "Aço Ferramenta D2", PesoTotal = 3100.00m, TemperaturaFundicao = 1480.0m, StatusQualidade = "Reprovado" }
};

loteService.SalvarCsv(lotesTurno, "producao_turno.csv");
var lotesLidos = loteService.CarregarCsv("producao_turno.csv");
decimal mediaTemp = loteService.CalcularMediaTemperatura(lotesLidos);

Console.WriteLine($"Lotes processados: {lotesLidos.Count} | Média de temperatura: {mediaTemp:F2} °C");
