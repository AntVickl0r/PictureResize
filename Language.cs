using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml.Serialization;

namespace PictureResize
{
    public class Language
    {
        public static void SerializeToXML(Language language, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Language));
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, language);
            textWriter.Close();
        }
        //
        public static Language DeserializeFromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Language));
            TextReader textReader = new StreamReader(path);
            Language language;
            language = (Language)deserializer.Deserialize(textReader);
            textReader.Close();

            return language;
        }
        //
        public string LANGUAGE = "Language";
        public string LANGUAGE_NAME = "English";
        public string LANGUAGE_FILENAME = "EN";
        //
        //--- RESIZE FORM ---//
        public string WIDTH = "Width";
        public string HEIGHT = "Height";
        public string FILESIZE = "File size";
        //
        public string SAVE = "Save";
        public string SAVE_AS = "Save as...";
        //
        //--- OVERWRITE DIALOG ---//
        public string WARNING = "Warning!";
        public string REALLY_OVERWRITE = "Do you really want to overwrite the original file?";
        //
        //--- RENAME DIALOG ---//
        public string RENAME = "Rename?";
        public string AUTO_RENAME = "Do you want to automatically rename the file?";
        //
        //--- CONTEXT MENU ---//
        public string RESIZE_IMAGE = "Resize image";
    }
}
