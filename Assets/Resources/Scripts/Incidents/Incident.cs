using System.Collections;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Incident {

	[XmlAttribute("name")]
	public string name;

	[XmlElement("Effect")]
	public string effect;

	[XmlElement("Duration")]
	public int duration;

	[XmlElement("Description")]
	public string description;
}
