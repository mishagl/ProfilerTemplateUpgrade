// See https://aka.ms/new-console-template for more information
if (args.Length != 2)
{
    System.Console.WriteLine("usage: ProfilerTemplateUpgrade <version>");
    Environment.Exit(-1);
}

var file = args[0];
if (!int.TryParse(args[1], out var version))
{
    System.Console.WriteLine($"{args[1]} - Version could not be parsed");
    Environment.Exit(-2);
}

System.Console.WriteLine($"Upgrading `{Path.GetFileNameWithoutExtension(file)}`");

var templateFile = File.ReadAllBytes(args[0]);
if (templateFile.Length < 391)
{
    Console.WriteLine($"File is corrupt. Length {templateFile.Length} bytes");
    Environment.Exit(-2);
}

var currentVersionHigh = templateFile[390];
var currentVersionLow = templateFile[319];

System.Console.WriteLine($"Version {currentVersionHigh} {currentVersionLow}");

if (currentVersionHigh == version)
{
    Console.WriteLine("Version match. Nothing todo.");
    Environment.Exit(0);
}

templateFile[390] = (byte)version;

var path = Path.GetDirectoryName(file);
var fileName = Path.GetFileNameWithoutExtension(file);

try
{
    File.WriteAllBytes(Path.Combine(path, $"{fileName}-{version}.tdf"), templateFile);
}
catch (IOException ioe)
{
    Console.Error.WriteLine(ioe.Message);
}
catch (Exception e)
{
    Console.Error.WriteLine(e.Message);
}
