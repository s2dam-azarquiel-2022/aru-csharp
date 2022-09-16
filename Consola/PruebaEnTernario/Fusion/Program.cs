string ciudad = null;
string etiqueta = ciudad ?? "indefinida";
Console.WriteLine(etiqueta);
ciudad = "VALENCIA";
etiqueta = ciudad ?? "indefinida";
Console.WriteLine(etiqueta);
