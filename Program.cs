using AsmResolver.IO;
using AsmResolver.PE;
using AsmResolver.PE.DotNet.Builder;
using AsmResolver.PE.DotNet.Metadata.UserStrings;

class Program
{
    static void Main(string[] args)
    {
        IPEImage iPEImage= PEImage.FromFile(@"D:\SteamLibrary\steamapps\common\Isle of Ewe\Isle Of Ewe_Data\Managed\Assembly-CSharp.dll"); //Original DLL
        var metadata = iPEImage.DotNetDirectory.Metadata;

        var userStringsStream = metadata.GetStream<SerializedUserStringsStream>();
        string value = userStringsStream.GetStringByIndex(0x072d);
        Console.WriteLine("Check value: " + value);

        byte[] newData = File.ReadAllBytes(@"D:\Ewe\#US.bin");
        var newStream = new SerializedUserStringsStream("#US", newData);

        metadata.Streams.RemoveAt(2);
        metadata.Streams.Insert(2, newStream);

        var builder = new ManagedPEFileBuilder();
        var newPEFile = builder.CreateFile(iPEImage);

        using (var stream = File.Create(@"D:\Ewe\Assembly-CSharp.dll")) //Choose a directory to save the file
        {
            var writer = new BinaryStreamWriter(stream);
            newPEFile.Write(writer);
        }
    }
}