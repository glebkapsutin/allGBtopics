using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;




using System;
[XmlRoot("DataRoot")]
public class DataRoot
{   [XmlArray("Data.Root.Names")]
    [XmlArrayItem("Name")]
    public string[] Names;
    [XmlElement(typeof(DataEntry))]
    public DataEntry Entry;
    [XmlElement(typeof(DataX))]
    public DataX X;
    
}
[XmlType("Data.Entry")]
public class DataEntry
{
    public string LinkedEntry;
    [XmlElement("Data.Name")]
    public string Name;

    
}
[XmlType("data_x0023")]
public class DataX{

    [XmlElement("Data.Name")]
    public string Name;
    [XmlElement("data_x00233")]
    public string DataExt;
}