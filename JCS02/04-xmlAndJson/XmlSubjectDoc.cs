﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _204
{
    [XmlRoot("predmetyKatedry")]
    internal class XmlSubjectDoc
    {
        [XmlElement("predmetKatedry")]
        public List<XmlSubjectItem> Predmety { get; set; } = new List<XmlSubjectItem>();
    }
}
