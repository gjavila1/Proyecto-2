class CuentaTercero
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string NumeroCuenta { get; set; }
    public string NombreBanco { get; set; }


    public CuentaTercero(int id, string nombre, string numeroCuenta, string nombreBanco)
    {
        Id = id;
        Nombre = nombre;
        NumeroCuenta = numeroCuenta;
        NombreBanco = nombreBanco;
    }
}