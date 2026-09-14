using UzdevumuParvaldnieksKlases;
using UzdevumuParvaldnieksKonsole;
using UzdevumuTestData;

Console.WriteLine("Hello, World!");

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

ITestDataFactory testDataFactory = new TestDataFactoryArray();
testDataFactory.CreateTestData();
Console.WriteLine(testDataFactory.ReturnTestData());

string path="test.json";
TestDataFactoryList tdfL = new TestDataFactoryList();
tdfL.FileName = path;
tdfL.CreateTestData();
Console.WriteLine(tdfL.ReturnTestData());
tdfL.SaveToFile();

TestDataFactoryList tdFL2 = new TestDataFactoryList();
tdFL2.FileName = path;
tdFL2.LoadFromFile();
Console.WriteLine(tdFL2.ReturnTestData());


//Animal a1 = new Dog();
//Animal a2 = null;

//Console.WriteLine(a1 is Dog);
//Console.WriteLine(a1 is Animal);
//Console.WriteLine(a2 is Dog);

//Dog d1 = a1 as Dog;
//Dog d2 = a2 as Dog;
//Console.WriteLine(d1?.Speak() ?? "No");
//Console.WriteLine(d2?.Speak() ?? "No");
