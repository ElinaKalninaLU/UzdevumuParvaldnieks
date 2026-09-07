using UzdevumuParvaldnieksKlases;

///Console.WriteLine("Hello, World!");

Uzdevums u1 = new Uzdevums(1, "Pirmais uzdevums", "Apraksts par pirmo uzdevumu");
Console.WriteLine(u1.Nosaukums);
u1.Apraksts = "Jauns uzdevuma apraksts";
u1.Nosaukums = "Jauns uzdevuma nosaukums";
Console.WriteLine(u1);
Console.WriteLine($"Nosaukums: {u1.Nosaukums} Apraksts: {u1.Apraksts}");

var u2 = new VienreizejsUzdevums();
u2.Nosaukums = "Vienreizējais uzdevums";
u2.Apraksts = "Apraksts par vienreizējo uzdevumu";
u2.Termins = DateTime.Now;
u2.VaiIrIzpildits = false;
Console.WriteLine(u2);
Uzdevums u3 = u2;
Console.WriteLine(u3);
