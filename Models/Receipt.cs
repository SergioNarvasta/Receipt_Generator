using System.Drawing;

namespace Receipt_Generator.Models
{
    public class Receipt
    {
       public int Id { get; set; }
       public string NroDoc { get; set; }
       public string Titulo { get; set; }
       public string Descripcion { get; set; }
       public string Moneda { get; set; }  //*
       public double Monto { get; set; }
       public string TipoDoc { get; set; } //*
       public string Direccion { get; set; }
       public string Nombres { get; set; }
       public Image Logo { get; set; }

    }
}
