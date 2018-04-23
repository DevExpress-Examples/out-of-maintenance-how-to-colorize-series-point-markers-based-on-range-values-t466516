using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;

namespace RangeColorizer3DExample.ViewModel {
    public class Gdp {
        public string Country { get; private set; }
        public int Year { get; private set; }
        public double Value { get; private set; }
        public string Region { get; private set; }

        public Gdp(string country, int year, double value, string region) {
            Country = country;
            Year = year;
            Value = value;
            Region = region;
        }
    }

    public class GdpViewModel {
        public IEnumerable<Gdp> Gdps { get; private set; }

        public GdpViewModel() {
            Gdps = new GdpResourceLoader("Data/GdpStatistics.xml").Load();
        }
    }

    public class GdpResourceLoader {
        string Filepath { get; set; }

        public GdpResourceLoader(string filepath) {
            Filepath = filepath;
        }

        public IEnumerable<Gdp> Load() {
            Collection<Gdp> result = new Collection<Gdp>();

            Uri resourceUri = new Uri(Filepath, UriKind.RelativeOrAbsolute);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(resourceUri);
            XDocument xDoc = XDocument.Load(resourceInfo.Stream);
            foreach (var xGdp in xDoc.Element("Statistics").Elements("Gdp")) {
                result.Add(new Gdp(
                    country: xGdp.Attribute("Country").Value,
                    year: Convert.ToInt32(xGdp.Attribute("Year").Value),
                    value: Convert.ToDouble(xGdp.Attribute("Value").Value),
                    region: xGdp.Attribute("Region").Value
                ));
            }
            return result;
        }
    }
}
