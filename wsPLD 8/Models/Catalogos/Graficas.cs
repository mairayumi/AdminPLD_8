namespace wsPLD_8.Models.Catalogos
{
    public class Graficas
    {
        public Graficas()
        {
            this.Graph1 = new Grafica();
            this.Graph2 = new Grafica();
        }

        public IList<GraficaTotales> Totales;
        public Grafica Graph1 { get; set; }
        public Grafica? Graph2 { get; set; }
    }

    public class Grafica
    {
        public IList<string> labels { get; set; }
        public string labeldata { get; set; }
        public IList<double> datas { get; set; }
        public string labeldata2 { get; set; }
        public IList<double> datas2 { get; set; }
    }

    public class GraficaTotales
    {
        public int Total { get; set; }
        public decimal Liverados { get; set; }
        public int EnProceso { get; set; }
        public int EnRevision { get; set; }
        public int Cancelado { get; set; }
        public int MejoraInterna { get; set; }
        public int Atrazado { get; set; }

    }
}
