using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("IncidentCollection")]
public class IncidentContainer {

	[XmlArray("Incidents")]
	[XmlArrayItem("Incident")]
	public List<Incident> incidents = new List<Incident>();

	public static IncidentContainer Load(string path){
		TextAsset _xml = Resources.Load<TextAsset> (path);

		XmlSerializer serializer = new XmlSerializer (typeof(IncidentContainer));

		StringReader reader = new StringReader (_xml.text);

		IncidentContainer incidents = serializer.Deserialize (reader) as IncidentContainer;

		reader.Close ();

		return incidents;
	}

}
