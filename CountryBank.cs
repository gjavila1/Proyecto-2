using System;
namespace CountryBankI;

public class Cuenta
{
    //Declaración de las propiedades de la clase, String.Empty inicializa la cadena vacia 
    public int id { get; set; }
    public string Owner { get; set; }
    public string NoCuenta { get; set; }
    public string Tcuenta { get; set; }
    public string DPI { get; set; }
    public string direccion { get; set; }
    public int telefono { get; set; }
    public decimal Saldo { get; set; }

    int i = 0;
    List<string[]> tcuentas = new List<string[]>();
    List<CuentaTercero> cuentasTerceros = new List<CuentaTercero>();
    public Cuenta() { }
    //El constructor 
    public Cuenta(string Owner, int id, string NoCuenta, string Tcuenta, string DPI, string direccion, int telefono, decimal abonar, decimal Saldo)
    {
        this.id = id;
        this.Owner = Owner;
        this.NoCuenta = NoCuenta;
        this.Tcuenta = Tcuenta;
        this.DPI = DPI;
        this.direccion = direccion;
        this.telefono = telefono;

        this.Saldo = Saldo;
    }
    public void GuardarDatos(string Owner, string NoCuenta, string Tcuenta, string DPI, string direccion, int telefono, decimal Saldo)
    {
        tcuentas.Add(new string[] { i.ToString(), Owner, NoCuenta, Tcuenta, DPI, direccion, telefono.ToString(), Saldo.ToString("0.00") });
        ++i;
    }
    public void Informacion()
    {
        foreach (var princuenta in tcuentas)
        {
            Console.WriteLine("\n*------------INFORMACIÓN DE LA CUENTA-------------*\n");
            Console.WriteLine($"ID de la cuenta: {princuenta[0]}");
            Console.WriteLine($"Propietario: {princuenta[1]}");
            Console.WriteLine($"Número de Cuenta: {princuenta[2]}");
            Console.WriteLine($"Tipo de Cuenta: {princuenta[3]}");
            Console.WriteLine($"DPI: {princuenta[4]}");
            Console.WriteLine($"Dirección: {princuenta[5]}");
            Console.WriteLine($"Teléfono: {princuenta[6]}");
            Console.WriteLine($"Saldo Actual: Q{princuenta[7]}");
        }
    }
    public decimal Saldito(int id)
    {
        return decimal.Parse(tcuentas[id][7]);
    }
    public void Gsaldo(int id, decimal monto)
    {
        tcuentas[id][7] = monto.ToString("0.00");
    }
    public void AgregarCuentaTercero(string nombre, string numeroCuenta, string nombreBanco)
    {
        // Generar un nuevo identificador único para la cuenta de tercero
        int nuevoId = cuentasTerceros.Count + 1;

        // Crear una nueva cuenta de tercero y agregarla a la lista
        CuentaTercero nuevaCuenta = new CuentaTercero(nuevoId, nombre, numeroCuenta, nombreBanco);
        cuentasTerceros.Add(nuevaCuenta);
    }
    public void EliminarCuentaTercero(int id)
    {
        // Buscar la cuenta de tercero por su ID y eliminarla de la lista
        CuentaTercero cuentaAEliminar = cuentasTerceros.Find(c => c.Id == id);
        if (cuentaAEliminar != null)
        {
            cuentasTerceros.Remove(cuentaAEliminar);
        }
        else
        {
            Console.WriteLine("No se encontró ninguna cuenta de tercero con el ID especificado.");
        }
    }
    public void ActualizarCuentaTercero(int id, string nombre, string numeroCuenta, string nombreBanco)
    {
        // Buscar la cuenta de tercero por su ID y actualizar sus propiedades
        CuentaTercero cuentaAActualizar = cuentasTerceros.Find(c => c.Id == id);
        if (cuentaAActualizar != null)
        {
            cuentaAActualizar.Nombre = nombre;
            cuentaAActualizar.NumeroCuenta = numeroCuenta;
            cuentaAActualizar.NombreBanco = nombreBanco;
        }
        else
        {
            Console.WriteLine("No se encontró ninguna cuenta de tercero con el ID especificado.");
        }
    }
    public void MostrarCuentasTerceros()
    {
        Console.WriteLine("\n*------------Cuentas de Terceros-------------*\n");

        foreach (var cuenta in cuentasTerceros)
        {
            Console.WriteLine($"ID: {cuenta.Id}, Nombre: {cuenta.Nombre}, Número de cuenta: {cuenta.NumeroCuenta}, Banco: {cuenta.NombreBanco}");
        }

        Console.WriteLine();
    }

}








