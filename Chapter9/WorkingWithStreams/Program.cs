using System.IO.Compression;
using System.Xml;

WorkingWithXml();
WorkingWithCompression();

static void WorkingWithText()
{
    string textFile = Path.Combine(Environment.CurrentDirectory, "streams.txt");

    StreamWriter text = File.CreateText(textFile);

    foreach (string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
    text.Close();

    Console.WriteLine($"{textFile} contains {new FileInfo(textFile).Length}");

    Console.WriteLine(File.ReadAllText(textFile));

};

static void WorkingWithXml()
{

    FileStream? xmlStream = null;
    XmlWriter? xml = null;

    try
    {
        string xmlFile = Path.Combine(Environment.CurrentDirectory, "streams.xml");
        xmlStream = File.Create(xmlFile);
        xml = XmlWriter.Create(xmlStream, new XmlWriterSettings { Indent = true });
        xml.WriteStartDocument();
        xml.WriteStartElement("callsigns");
        foreach (string item in Viper.Callsigns)
        {
            xml.WriteElementString("callsign", item);
        }
        xml.WriteEndElement();
        xml.Close();
        xmlStream.Close();

        Console.WriteLine($"{xmlStream} contains {new FileInfo(xmlFile).Length}");

        Console.WriteLine(File.ReadAllText(xmlFile));
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if(xml != null)
        {
            xml.Dispose();
            Console.WriteLine("XML DISPOSED");
        }
        if(xmlStream != null)
        {
            xmlStream.Dispose();
            Console.WriteLine("XML file DISPOSED");
        }

        // Вместо dispose можно использовать using
    }
}

static void WorkingWithCompression()
{
    string fileExt = "gzip";
    string filePath = Path.Combine(Environment.CurrentDirectory, $"streams.{fileExt}");

    FileStream file = File.Create(filePath);
    Stream compressor = new GZipStream(file, CompressionMode.Compress);

    using(compressor)
    {
        using XmlWriter xml = XmlWriter.Create(compressor);
        xml.WriteStartDocument();
        xml.WriteStartElement("callsigns");
        foreach(string item in Viper.Callsigns)
        {
            xml.WriteElementString("callsign", item);

        }
    }
    Console.WriteLine($"{filePath} contains {new FileInfo(filePath).Length}");
    Console.WriteLine($"The compressed contents:");
    Console.WriteLine(File.ReadAllText(filePath));

    Console.WriteLine("Open compressed File");
    file = File.Open(filePath, FileMode.Open);

    Stream decompressor = new GZipStream(file, CompressionMode.Decompress);

    using(decompressor)
    {
        using (XmlReader reader = XmlReader.Create(decompressor))
        {
            while(reader.Read())
            {
                if((reader.NodeType == XmlNodeType.Element) && (reader.Name =="callsign"))
                {
                    reader.Read();
                    Console.WriteLine(reader.Value);
                }
            }
        }    
        
    }
}

static class Viper
{
    public static string[] Callsigns = [
        "Husker", "Starbuck", "Apollo", "Boomer",
        "Bulldog", "Athena", "Helo", "Racetrack"
    ];
}

