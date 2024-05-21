using System.Runtime.InteropServices;

namespace CountryBankI;

class Transacciones
{
    public DateTime Fecha { get; set; }
    public decimal Mopera { get; set; }
    public string Debcred { get; set; }

    public Transacciones() { }

    int i = 1;
    List<string[]> transacciones = new List<string[]>();
    public Transacciones(DateTime fecha, decimal mopera, string debcred)
    {
        this.Fecha = fecha;
        this.Mopera = mopera;
        this.Debcred = debcred;
    }

    public void TransData(DateTime fecha, decimal Mopera, string debcred)
    {
        transacciones.Add(new string[] { i.ToString(), fecha.ToString(), Mopera.ToString(), debcred });
        ++i;
    }
    public void datosm() //mostrar transacciones
    {
        Console.WriteLine("Transacciones:");
        foreach (var printa in transacciones)
        {
            Console.WriteLine($"{printa[0]}. {printa[1]} - Q{printa[2]} - {printa[3]}");
        }
    }

}






