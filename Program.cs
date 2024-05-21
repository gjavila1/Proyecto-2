using System.Globalization;
using System.Text.RegularExpressions;
using CountryBankI;


class Programa
{
    
    static Cuenta cuenta = new Cuenta();
    static Transacciones tansito = new Transacciones();

    
    static void Main(string[] args)
    {
        crearcuenta();
        MenuI();
    }
    #region Crearcuenta
    //Solicitamos los datos del propietario de la cuenta
    static void crearcuenta()
    {
        Console.WriteLine("Bienvenido al sistema de Country Bank");
        Console.WriteLine("Por favor, introduzca la siguiente información para crear su cuenta:");

        //Validamos la variable Owner
        string Owner = "";
        while (true)
        {
            Console.Write("Nombre: ");
            Owner = Console.ReadLine();
            if (ValidacioNombre(Owner))
            {
                break;
            }
            else
            {
                Console.WriteLine("Nombre inválido. Por favor, intente de nuevo.");
            }
        }

        Console.Write("Número de Cuenta: ");
        string NoCuenta = Console.ReadLine();

        //Validacion de Tcuenta, para la eleccion del tipo de cuenta.
        string Tcuenta = "";
        while (true)
        {
            Console.WriteLine("Tipo de cuenta (monetaria quetzales, monetaria dólares, ahorro quetzales, ahorro dólares): ");
            Tcuenta = Console.ReadLine().ToLower();
            if (Tcuenta == "monetaria quetzales" || Tcuenta == "ahorro quetzales" || Tcuenta == "monetaria Dolares" || Tcuenta == "ahorro dolares")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ingrese de nuevo su tipo de cuenta");
            }
        }
        //Validacion DPI, la cual permite ingresar 5 caracteres para DPI.
        string DPI = "";
        while (true)
        {
            Console.Write("Numero de DPI: ");
            DPI = Console.ReadLine();
            if (DPI.Length == 5)
            {
                break;
            }
            else
            {
                Console.Write("Numero de DPI invalido.\n");
            }
        }
        Console.Write("Direccion: ");
        string direccion = Console.ReadLine();

        //Validacion telefono.
        int telefono = 0;
        while (true)
        {
            Console.Write("Numero de telefono: ");

            if (int.TryParse(Console.ReadLine(), out telefono))
            {
                break;
            }
            else
            {
                Console.WriteLine("Numero de teléfono invalido. Por favor, intente de nuevo.");
            }
        }

        decimal Saldo = 2500;
        Console.WriteLine($"Su saldo es de: Q{Saldo.ToString("0.00")}\n");

        cuenta.GuardarDatos(Owner, NoCuenta, Tcuenta, DPI, direccion, telefono, 2500.00m);
    }
    #endregion
    static bool ValidacioNombre(string simbolos)
    {
        // Verificar que solo contenga letras y espacios
        string signos = @"^[a-zA-Z\s]+$";
        return Regex.IsMatch(simbolos, signos);
    }
    #region Menu En Linea
    public static void MenuI()
    {
        string[] menu1 = { "Ver informacion de la cuenta", "Comprar producto financiero", "Vender producto financiero", "Abonar a cuenta", "Simular paso del tiempo", "Mantenimiento de cuentas de terceros", "Transferencias a otras cuentas", "Pago de servicios", "Imprimir informe de transacciones", "Salir" };
        bool opcion1 = true;
        do
        {
            Console.WriteLine("\n*------------MENU EN LINEA-------------*");
            for (int i = 0; i < menu1.Length; i++)
            {
                Console.WriteLine($"{i + 1}.{menu1[i]}");
            }
            Console.WriteLine("\nElija segun su nesecidad: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    cuenta.Informacion();
                    break;

                case "2":
                    Comprar();
                    break;

                case "3":
                    Vender();
                    break;

                case "4":
                    Abonar();
                    break;

                case "5":
                    Simular();
                    break;

                case "6":
                    //Se llama al metodo para crear, editar y eliminar cuentas
                    Mantenimiento();
                    break;

                case "7":
                    //Se llama al metodo para transferir a otras cuentas
                    Transferencias();
                    break;

                case "8":
                    //Se llama al metodo para pagar servicios
                    PagoServ();
                    break;

                case "9":   
                    tansito.datosm();
                    break;

                case "10":
                    Console.WriteLine("\n*-----------------FELIZ DIA------------------*\n");
                    opcion1 = false;
                    break;
                default:
                    Console.WriteLine("\n*-----------------------------------------*");
                    Console.WriteLine("La opcion que usted realizo no es valida");
                    Console.WriteLine("\nPresiona Enter para continuar.");
                    break;
            }
        } while (opcion1);
    }
    #endregion
    #region Comparar
    public static void Comprar()
    {
        //Se realizo la accion para comprar un producto financiero
        decimal Saldo = cuenta.Saldito(0);
        decimal monto1 = Saldo * 0.10m;
        Saldo = Saldo - monto1;

        Console.WriteLine("\n*------------COMPRA DE PRODUCTO FINANCIERO-------------*\n");
        Console.WriteLine($"Compra realizada. \nSaldo actual: Q{Saldo.ToString("0.00")}");

        cuenta.Gsaldo(0, Saldo);
        tansito.TransData(DateTime.Now, Saldo, "Debito");
    }
    #endregion
    #region Vender
    public static void Vender()
    {
        decimal Saldo = cuenta.Saldito(0);
        if (Saldo > 500)
        {
            //Realizamos la accion para Vender un producto financiero
            decimal monto2 = Saldo * 0.11m;
            Saldo = Saldo + monto2;

            Console.WriteLine($"Venta realizada.\nSaldo actual: Q{Saldo.ToString("0.00")}");
            cuenta.Gsaldo(0, Saldo);
            tansito.TransData(DateTime.Now, Saldo, "Credito");
        }
        else
        {
            Console.WriteLine("No se puede realizar la venta. Saldo insuficiente.");
        }
    }
    #endregion
    #region Abonar
    static decimal abonar = 0;
    public static void Abonar()
    {   
        //Realizamos la accion para abonar a la cuenta
        decimal Saldo = cuenta.Saldito(0);
        if (Saldo > 500 && abonar < 2)
        {
            Saldo *= 2;
            abonar++;

            Console.WriteLine($"Abono realizado.\nSaldo actual: Q{Saldo.ToString("0.00")}");
            cuenta.Gsaldo(0, Saldo);
            tansito.TransData(DateTime.Now, Saldo, "Credito");
        }
        else
        {
            Console.WriteLine("No se puede realizar el abono. Saldo insuficiente o abonos máximos alcanzados.");
        }
    }
    #endregion
    #region Simular
    public static void Simular()
    {
        decimal Saldo = 0;

        //Se solicita el periodo de capitalizacion
        Console.WriteLine("\n*------------CAPITALIZACION------------*\n");
        Console.WriteLine("Ingrese el periodo de capitalizacion");
        Console.WriteLine("1.Una vez al mes\n2.Dos veces al mes");
        char opcion2 = Console.ReadKey().KeyChar;

        //Validamos la accion que desea realizar el usuario 
        switch (opcion2)
        {

            case '1':
                {
                    //Realizamos la accion de capitalizacion (Una vez al mes)
                    Console.WriteLine("\n-----------------------------------------");
                    Saldo = cuenta.Saldito(0);
                    Saldo = Saldo + (Saldo * 0.02m);
                    Console.WriteLine($"Su saldo actual por el interes de 1 mes es de: Q{Saldo.ToString("0.00")}");
                    Console.WriteLine("\nPresiona Enter para continuar.");
                    cuenta.Gsaldo(0, Saldo);
                    tansito.TransData(DateTime.Now, Saldo, "Debito");
                    break;
                }
            case '2':
                {
                    //Realizamos la accion de capitalizacion (Dos veces al mes)
                    Console.WriteLine("\n-----------------------------------------");
                    Saldo = cuenta.Saldito(0);
                    Saldo = Saldo + (Saldo * 2);
                    Console.WriteLine($"Su saldo actual por el interes de 2 meses es de: Q{Saldo.ToString("0.00")}");
                    Console.WriteLine("\nPresiona Enter para continuar.");
                    cuenta.Gsaldo(0, Saldo);
                    tansito.TransData(DateTime.Now, Saldo, "Debito");
                    break;
                }
            default:
                {

                    //Si no se cumplen los criterios de la accion que quiere realizar el usuario se muestran mensajes
                    Console.WriteLine("\n-----------------------------------------");
                    Console.WriteLine("La opcion que usted realizo no es valida");
                    Console.WriteLine("\nPresiona Enter para continuar.");
                    break;
                }
        }
    }
    #endregion
    #region Mantenimiento
    public static void Mantenimiento()
    {
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearCuentaTercero();
                    break;
                case "2":
                    EliminarCuentaTercero();
                    break;
                case "3":
                    ActualizarCuentaTercero();
                    break;
                case "4":
                    cuenta.MostrarCuentasTerceros();
                    break;
                case "5":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }
        }

    }
    static void MostrarMenu()
    {
        Console.WriteLine("\n*------------Mantenimiento de Cuentas de Terceros-------------*\n");
        Console.WriteLine("1. Crear Cuenta de Tercero");
        Console.WriteLine("2. Eliminar Cuenta de Tercero");
        Console.WriteLine("3. Actualizar Cuenta de Tercero");
        Console.WriteLine("4. Mostrar Cuentas de Terceros");
        Console.WriteLine("5. Salir");
        Console.Write("\nSeleccione una opción: ");
    }
    static void CrearCuentaTercero()
    {
        Console.WriteLine("\n*------------Crear Cuenta de Tercero-------------*\n");

        // Solicitar información al usuario
        Console.Write("Nombre del cuentahabiente: ");
        string nombre = Console.ReadLine();

        Console.Write("Número de cuenta: ");
        string numeroCuenta = Console.ReadLine();

        Console.Write("Nombre del banco: ");
        string nombreBanco = Console.ReadLine();

        // Agregar la cuenta de tercero
        cuenta.AgregarCuentaTercero(nombre, numeroCuenta, nombreBanco);

        Console.WriteLine("Cuenta de tercero creada con éxito.");

    }
    static void EliminarCuentaTercero()
    {
        Console.WriteLine("\n*------------Eliminar Cuenta de Tercero-------------*\n");

        // Mostrar las cuentas de terceros disponibles
        cuenta.MostrarCuentasTerceros();

        // Solicitar al usuario el ID de la cuenta de tercero a eliminar
        Console.Write("Ingrese el ID de la cuenta de tercero que desea eliminar: ");
        int id = int.Parse(Console.ReadLine());

        // Eliminar la cuenta de tercero
        cuenta.EliminarCuentaTercero(id);

        Console.WriteLine("Cuenta de tercero eliminada con éxito.");
    }
    static void ActualizarCuentaTercero()
    {
        Console.WriteLine("\n*------------Actualizar Cuenta de Tercero-------------*\n");

        // Mostrar las cuentas de terceros disponibles
        cuenta.MostrarCuentasTerceros();

        // Solicitar al usuario el ID de la cuenta de tercero a actualizar
        Console.Write("Ingrese el ID de la cuenta de tercero que desea actualizar: ");
        int id = int.Parse(Console.ReadLine());

        // Solicitar información actualizada al usuario
        Console.Write("Nuevo nombre del cuentahabiente: ");
        string nombre = Console.ReadLine();

        Console.Write("Nuevo número de cuenta: ");
        string numeroCuenta = Console.ReadLine();

        Console.Write("Nuevo nombre del banco: ");
        string nombreBanco = Console.ReadLine();

        // Actualizar la cuenta de tercero
        cuenta.ActualizarCuentaTercero(id, nombre, numeroCuenta, nombreBanco);

        Console.WriteLine("Cuenta de tercero actualizada con éxito.");
    }
    static void Transferencias()
    {
        Console.WriteLine("\n*------------TRANSFERENCIAS A OTRAS CUENTAS-------------*\n");

        // Mostrar detalles de las cuentas disponibles para transferir
        cuenta.MostrarCuentasTerceros();

        // Solicitar información para la transferencia
        Console.Write("Ingrese el ID de la cuenta a la cual desea transferir dinero: ");
        int idDestino = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el monto a transferir (entre Q200.00 y Q2000.00): ");
        decimal monto = decimal.Parse(Console.ReadLine());

        // Validar que el monto esté dentro del rango permitido
        if (monto < 200 || monto > 2000)
        {
            Console.WriteLine("El monto ingresado está fuera del rango permitido.");
            return;
        }

        // Realizar la transferencia
        decimal saldoActual = cuenta.Saldo;
        if (saldoActual >= monto)
        {
            // Restar el monto transferido al saldo de la cuenta
            saldoActual -= monto;
            cuenta.Saldo = saldoActual;

            Console.WriteLine($"Transferencia de Q{monto} realizada correctamente a la cuenta con ID {idDestino}.");
            Console.WriteLine($"Saldo actual: Q{saldoActual}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
        }
        tansito.TransData(DateTime.Now, saldoActual, "Credito");
    }
    #endregion

    #region Pago de servicios
    public static void PagoServ()
    {
        string[] menu2 = { "Empresa de Agua", "Empresa Electrica", "Empresa Telefonica" };
        Console.WriteLine("\n*------------PAGO DE SERVICIOS------------*\n");
        Console.WriteLine("Seleccione el proveedor de servicios:");
        for (int i = 0; i < menu2.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {menu2[i]}");
        }

        int opcion;
        if (!int.TryParse(Console.ReadLine(), out opcion)) //La negacion de int.TryParse, se refiere a si falla la condicion del if sera true.
        {
            Console.WriteLine("Opción inválida. Por favor, seleccione un número entre 1 y 3.");
            return;
        }

        decimal monto;
        switch (opcion)
        {
            case 1:
                Console.WriteLine("Ha seleccionado pagar a la Empresa de Agua.");
                monto = IngresarMonto();
                if (monto > 0)
                {
                    PagarServicio("Empresa de Agua", monto);
                }
                break;
            case 2:
                Console.WriteLine("Ha seleccionado pagar a la Empresa Eléctrica.");
                monto = IngresarMonto();
                if (monto > 0)
                {
                    PagarServicio("Empresa Eléctrica", monto);
                }
                break;
            case 3:
                Console.WriteLine("Ha seleccionado pagar a Telefónica.");
                monto = IngresarMonto();
                if (monto > 0)
                {
                    PagarServicio("Telefónica", monto);
                }
                break;
            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione un número entre 1 y 3.");
                break;
        }
    }
    #endregion
    static decimal IngresarMonto()
    {
        decimal monto;
        while (true)
        {
            Console.Write("Ingrese el monto del pago en quetzales: ");
            if (decimal.TryParse(Console.ReadLine(), out monto) && monto > 0)
            {
                return monto;
            }
            else
            {
                Console.WriteLine("Monto inválido. Por favor, ingrese un monto válido en quetzales.");
            }
        }
    }


    static void PagarServicio(string proveedor, decimal monto)
    {
        decimal saldo = cuenta.Saldito(0);

        if (saldo >= monto)
        {
            saldo -= monto;
            cuenta.Gsaldo(0, saldo);
            Console.WriteLine($"Pago de servicios a '{proveedor}' realizado correctamente. Saldo actual: Q{saldo:0.00}");
            tansito.TransData(DateTime.Now, monto, "Débito");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar el pago de servicios.");
        }
    }
}

