using System.IO;
using System.Xml.Serialization;

namespace ShipmentTracker
{
    public static class ShipmentTrackerHelper
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(ShipmentInfo));
        public static void WriteToFile(string filename, ShipmentInfo data)
        {
            using (var filestream = File.Create(filename))
            {
                Xs.Serialize(filestream, data);
            }
        }

        public static ShipmentInfo LoadFromFile(string filename)
        {
            using (var filestream = File.OpenRead(filename))
            {
                return (ShipmentInfo)Xs.Deserialize(filestream);
            }
        }

        public static ShipmentInfo LoadFromStream(Stream file)
        {
            return (ShipmentInfo)Xs.Deserialize(file);
        }
    }
}
