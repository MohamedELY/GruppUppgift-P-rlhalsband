using GruppUppgift_Pärlhalsband.Model;

//Creating instanses 
var n1 = Neackless.Factory.RandomeNecklessData(35);
var pearl1 = new Pearl();

//Writing out neckless, sorting it and Writing it out agien
Console.WriteLine(n1);
n1.Sort();
Console.WriteLine(n1);

//Searching for a pearl and print the place of the pearl
Console.WriteLine(n1.Search(pearl1));
Console.WriteLine(pearl1);