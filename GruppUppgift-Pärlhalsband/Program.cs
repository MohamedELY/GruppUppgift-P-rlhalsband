
using GruppUppgift_Pärlhalsband.Model;

var n1 = Neackless.Factory.RandomeNecklessData(35);
var ball = new Pearl();

Console.WriteLine(n1);

n1.Sort();

Console.WriteLine(n1);

Console.WriteLine(n1.Search(ball));
Console.WriteLine(ball);