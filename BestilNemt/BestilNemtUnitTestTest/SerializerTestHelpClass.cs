using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BestilNemtUnitTestTest
{
     public class SerializerTestHelpClass
    {
        //Based on https://msdn.microsoft.com/en-us/library/mt693218.aspx
        public static T TestSerialize<T>(T objectToSerialize)
            where T : class
        {
            // The debug.Writeline will not be called in tests, but you can use them while debugging.
            object deserializedObject;
            // Initializing an instance of the same serializer as WCF uses under the hoods
            var dataContractSerializer = new DataContractSerializer(typeof(T));
            //Serialize
            // Remember that using statements works as a try catch finally statements. The purpose is to make sure that the fileStream will be close no matter what
            using (var fileStream = File.Open("test" + typeof(T).Name + ".xml", FileMode.Create))
            {
                System.Diagnostics.Debug.WriteLine("Testing for type: {0}", typeof(T));
                // After running the test, you examine the result of the serialized file 
                // by right-clicking on WCFTests project -> Open folder in file explorer -> WCFTests -> bin -> Debug and find the xml file (e.g. testStudent.xml)
                dataContractSerializer.WriteObject(fileStream, objectToSerialize);
            }
            // Deserialize
            using (var fs = File.Open("test" + typeof(T).Name + ".xml", FileMode.Open))
            {
                deserializedObject = dataContractSerializer.ReadObject(fs);
                if (deserializedObject == null)
                    System.Diagnostics.Debug.WriteLine("  Deserialized object is null");
                else
                    System.Diagnostics.Debug.WriteLine("  Deserialized type: {0}", deserializedObject.GetType());
            }

            return deserializedObject as T;
        }
    }
}

