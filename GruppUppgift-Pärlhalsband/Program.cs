using GruppUppgift_Pärlhalsband.Model;
using System.IO.Compression;
/*
//Creating instanses 
var n1 = Neacklace.Factory.RandomeNecklessData(35);
var pearl1 = new Pearl();

//Writing out neckless, sorting it and Writing it out agien
Console.WriteLine(n1);
n1.Sort();
Console.WriteLine(n1);

//Searching for a pearl and print the place of the pearl
Console.WriteLine(n1.Search(pearl1));
Console.WriteLine(pearl1);
*/

Inventory myInventory = Inventory.Factory.RandomeInventoryData(5, 10);

//Save File to computer
using (Stream s = File.Create(fname("InventoryUncompressed.text")))
using (TextWriter w = new StreamWriter(s))
	w.Write($"{myInventory}\n\nTotal Price of inventory:{myInventory.Price}\n\nMost Expansive Pearl:\n{myInventory.MostExpansivePerl()}");


//Compress file to computer
using (Stream s = File.Create(fname("InventoryCompressed.bin")))
using (Stream ds = new DeflateStream(s, CompressionMode.Compress))
using (TextWriter w = new StreamWriter(ds))
	w.Write(myInventory);


//Copy Files
string destinationFolder = @"C:\Users\46769\AppData\Local\ADOP\ExamplesCopy\";
string[] files = Directory.GetFiles(@"C:\Users\46769\AppData\Local\ADOP\Examples\");
for (int i = 0; i < files.Length; i++)
{
	File.Copy(files[i], $"{destinationFolder}{"Copy" + Path.GetFileName(files[i])}", true);
}


//Compress file to computer using ZIP
using (Stream s = File.Create(fname("InventoryCompressedZip.zip")))
using (Stream ds = new GZipStream(s, CompressionMode.Compress))
using (TextWriter w = new StreamWriter(ds))
	w.Write(myInventory);


var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

string startPath = Path.Combine(documentPath, "ADOP", "Examples");
string zipFile = Path.Combine(documentPath, "ADOP", "Examples.zip");
string extractPath = Path.Combine(documentPath, "ADOP", "Extract");

if (File.Exists(zipFile)) File.Delete(zipFile);
ZipFile.CreateFromDirectory(startPath, zipFile);
Console.WriteLine($"Zip Created: {zipFile}");

if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
ZipFile.ExtractToDirectory(zipFile, extractPath);
Console.WriteLine($"Zip Extracted: {extractPath}\n");

using (ZipArchive archive = ZipFile.OpenRead(@"C:\Users\46769\AppData\Local\ADOP\Examples.zip"))
{
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        Console.WriteLine(entry);
    }
}

static string fname(string name)
{
	//LocalApplicationData is a good place to store a temporary file
	var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	documentPath = Path.Combine(documentPath, "ADOP", "Examples");
	if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
	return Path.Combine(documentPath, name);
}