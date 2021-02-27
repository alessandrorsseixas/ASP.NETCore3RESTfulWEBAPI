using System;

namespace RallyDakar.Dominio.Entidades
{
    public class Telemetria
    {
        public int Id { get; set; }
        public int TemporadaId { get; set; }
        public int PilotoId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public Decimal PercentualCombustivel { get; set; }
        public double Velocidade { get; set; }
        public double RPM { get; set; }
        public int TemperaturaExterna { get; set; }
        public int TemperaturaMotor { get; set; }
        public double AltitudeNivelMar { get; set; }
        public bool PedalAcelerador { get; set; }
        public bool PedalFreio { get; set; }
        public virtual Temporada Temporada { get; set; }
        public virtual Piloto Piloto { get; set; }
    }
}
