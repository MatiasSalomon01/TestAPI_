namespace TestAPI_.Entities
{

    public class TablaPadre
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<TablaUnoDos> TablaUnoDos { get; set; }
    }
    public class TablaUno : TablaPadre
    {
    }

    public class TablaDos : TablaPadre
    {
    }

    public class TablaUnoDos
    {
        public int Id { get; set; }
        public int TablaUnoId { get; set; }
        public TablaUno TablaUno { get; set; }
        public int TablaDosId { get; set; }
        public TablaDos TablaDos { get; set; }
    }
}
