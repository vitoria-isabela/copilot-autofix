using Newtonsoft.Json;
using System.Xml;

public class WebService
{
    /// <summary>
    /// VULNERABILITY: XML External Entity (XXE).
    /// DtdProcessing.Parse allows external entities to be processed, which can lead to information disclosure.
    /// </summary>
    public string ProcessXml(string xmlContent)
    {
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.DtdProcessing = DtdProcessing.Parse; // Insecure!

        using (XmlReader reader = XmlReader.Create(new StringReader(xmlContent), settings))
        {
            while (reader.Read()) { /* processing XML */ }
            return "XML Processado";
        }
    }

    /// <summary>
    /// VULNERABILITY: Insecure Deserialization.
    /// Deserializing untrusted JSON data without proper type handling can lead to vulnerabilities.
    /// </summary>
    public object DeserializeJson(string jsonData)
    {
        // MUDOU: Usando a biblioteca Newtonsoft.Json
        return JsonConvert.DeserializeObject(jsonData);
    }
}