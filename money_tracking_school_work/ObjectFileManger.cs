using System.Runtime.Serialization;
using System.Xml;

namespace money_tracking_school_work
{
    // ObjectFileManger is used to save and load object with file. Source https://www.youtube.com/watch?v=GzZu3eYDBmM
    // To use this need to be done to class of object.
    // Classes used most have [DataContract] above them.
    // Field in class most have [DataMember] above them.
    internal class ObjectFileManger
    {
        // Save object to file.
        // SerializableObject object to be saved.
        // Filepath path that include file name of file to save to.
        static public void SaveViaDataContractSerialization<T>(T serializableObject, string filepath)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            var writer = XmlWriter.Create(filepath, settings);
            serializer.WriteObject(writer, serializableObject);
            writer.Close();
        }

        // Load object from file.
        // Filepath path that include file name of file to load from.
        static public T LoadViaDataContractSerialization<T>(string filepath)
        {
            var fileStream = new FileStream(filepath, FileMode.Open);
            var reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            var serializer = new DataContractSerializer(typeof(T));
            T serializableObject = (T)serializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();
            return serializableObject;
        }
    }
}
