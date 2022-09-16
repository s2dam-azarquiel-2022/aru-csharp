int numClientes = 98;
string etiqueta = numClientes <= 100 ?
    numClientes.ToString() + " clientes" :
    "Mas de 100 clientes";

Console.WriteLine(etiqueta);
