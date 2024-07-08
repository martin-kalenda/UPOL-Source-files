using _204;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

// ********* 01 ********* //

// convert xml node to json
string buildJsonNode(XmlNode node)
{
    StringBuilder elementBuilder = new StringBuilder();
	// prepare data array for each element of node
    string[] data = new string[node.ChildNodes.Count];
    int i = 0;

	// start json node
    elementBuilder.Append("\t\t\n\t\t{\n");
	foreach (XmlNode element in node.ChildNodes)
	{
		// add element to data array
		data[i] = $"\t\t\t\"{element.Name}\": \"{element.InnerText}\"";
		i++;
	}
	// complete json node
	elementBuilder.Append(String.Join(",\n", data));
    elementBuilder.Append("\n\t\t}");

    return elementBuilder.ToString();
}
// read all students from xml and write students of second year to json with stylistic padding
// manual conversion required, so no class is used
// exceptions are neglected because I was running out of time
void readStudentsWriteSecondYear(string readFrom, string writeTo, bool overwrite = false)
{
	try
	{
        if (!overwrite && File.Exists(writeTo))
        {
            throw new Exception("File already exists and overwrite is set to false.");
        }

        // load xml document
        XmlDocument doc = new XmlDocument();
        doc.Load(readFrom);

        // get root element
        XmlElement? root = doc.DocumentElement;

        StringBuilder jsonBuilder = new StringBuilder();

        // if root element exists
        if (root != null)
        {
            // get it's child nodes
            XmlNodeList nodes = root.ChildNodes;
            List<string> entries = new List<string>();

            jsonBuilder.Append("{\n\t\"" + root.Name + "\": [");

            foreach (XmlNode node in nodes)
            {
                XmlNode? year = node.SelectSingleNode("rocnik");

                // check if year is 2
                if (year != null && year.InnerText == "2")
                {
                    // convert node to json
                    entries.Add(buildJsonNode(node));
                }
            }
            jsonBuilder.Append(String.Join(",", entries));
            jsonBuilder.Append("\n\t]\n}");
        }
        // write json to file
        File.WriteAllText(writeTo, jsonBuilder.ToString());
    }
	catch (Exception e)
	{
		Console.WriteLine("An error occured: " + e.Message);
		throw;
	}
}

//********* 02 ********* //

// read covid data from json, calculate moving average and write to xml
// exceptions are neglected because I was running out of time
void readCovidWriteAverages(string readFrom, string writeTo, bool overwrite = false)
{
	try
	{
        if (!overwrite && File.Exists(writeTo))
        {
            throw new Exception("File already exists and overwrite is set to false.");
        }

        // read json from file
        string jsonString = File.ReadAllText(readFrom);

        // deserialize json to object
        JsonCovidDoc? jsonDoc = JsonSerializer.Deserialize<JsonCovidDoc>(jsonString);

        // if deserialization was successful
        if (jsonDoc != null)
        {
            Queue<JsonCovidItem> infectedSevenDays = new Queue<JsonCovidItem>();
            
            DateTime startDate;
            DateTime endDate;
            List<double> averages = new List<double>();

            int entryCount = jsonDoc.Data.Count;
            int interval = entryCount < 7 ? entryCount : 7;
            int i = 0;

            // fill queue with first 7 days or less, depending on the number of entries
            while (i < interval)
            {
                infectedSevenDays.Enqueue(jsonDoc.Data[i]);
                i++;
            }
            startDate = infectedSevenDays.First().Date;
            endDate = infectedSevenDays.Last().Date;

            // create xml document
            XmlCovidDoc xmlDoc = new XmlCovidDoc();
            xmlDoc.Modified = jsonDoc.Modified;
            xmlDoc.Source = jsonDoc.Source;

            List<XmlCovidItem> xmlItems = new List<XmlCovidItem>();

            // calculate weekly moving averages and add them to xml
            while (i < entryCount)
            {
                XmlCovidItem xmlItem = new XmlCovidItem();
                xmlItem.StartDate = startDate;
                xmlItem.EndDate = endDate;
                xmlItem.MovingAverage = infectedSevenDays.Sum(x => x.InfectedIncremental) / (double)interval;
                xmlItems.Add(xmlItem);

                // dequeue first day
                infectedSevenDays.Dequeue();

                if (++i < entryCount)
                {
                    // enqueue next day
                    infectedSevenDays.Enqueue(jsonDoc.Data[i]);
                }
                else
                {
                    break;
                }
            }
            xmlDoc.Data = xmlItems;

            // serialize xml document to file
            TextWriter tw = new StreamWriter(writeTo);
            XmlSerializer sr = new XmlSerializer(typeof(XmlCovidDoc));
            sr.Serialize(tw, xmlDoc);
            tw.Close();
        }

    }
	catch (Exception e)
	{
        Console.WriteLine("An error occured: " + e.Message);
		throw;
	}
}


// driver code

// ********* 01 ********* //
// XML source path for readStudentsWriteSecondYear goes here
string studentsReadPath = @"C:\Users\Marti\Desktop\studentiPredmetu.xml";

// JSON destination path for readStudentsWriteSecondYear goes here
string studentsWritePath = @"C:\Users\Marti\Desktop\studentiPredmetu.json";

readStudentsWriteSecondYear(studentsReadPath, studentsWritePath, true);


// ********* 02 ********* //
// JSON source path for readCovidWriteAverages goes here
string covidReadPath = @"C:\Users\Marti\Desktop\nakaza.json";

// XML destination path for readCovidWriteAverages goes here
string covidWritePath = @"C:\Users\Marti\Desktop\nakaza.xml";

readCovidWriteAverages(covidReadPath, covidWritePath, true);