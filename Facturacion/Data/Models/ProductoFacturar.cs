namespace Facturacion.Data.Models
{
    public class ProductoFacturar
    {
        public Facturable? Facturable { get; set; }
        public byte Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioFinal { get { return Precio * Cantidad; } }
    }
}
