using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace WpfPhoneStores
{
    public class PhoneViewModel
    {
        public string Model { get; set; }
        
        public OperatingSystemViewModel OS { get; set; }

        public string Vendor { get; set; }

        public string Year { get; set; }

        public static Expression<Func<XElement, PhoneViewModel>> FromXElement
        {
            get
            {
                return e =>
                    new PhoneViewModel
                    {
                        Year = e.Element("year").Value,
                        Model = e.Element("model").Value,
                        Vendor = e.Element("vendor").Value,
                        OS = new OperatingSystemViewModel()
                        {
                            Name = e.Element("os").Element("name").Value,
                            Version = e.Element("os").Element("version").Value,
                            Manufacturer = e.Element("os").Element("manufacturer").Value
                        }
                    };
            }
        }
    }
}