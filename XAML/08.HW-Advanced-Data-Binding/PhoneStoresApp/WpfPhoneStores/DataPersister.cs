using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace WpfPhoneStores
{
    public class DataPersister
    {
        public static IEnumerable<StoreViewModel> GetStores(string StoresDocumentPath)
        {
            var storesDocumentRoot = XDocument.Load(StoresDocumentPath).Root;

            var stors = storesDocumentRoot.Elements("store");
            var storesVMs =
                           from storeElement in stors
                           select new StoreViewModel()
                           {
                               Name = storeElement.Element("name").Value,
                               Phones = storeElement.Elements("phone").AsQueryable().Select(PhoneViewModel.FromXElement)
                           };
            return storesVMs;
        }


        internal static void AddStore(string documenPath, string name, IEnumerable<PhoneViewModel> phones)
        {
            var storeModel = new StoreViewModel()
            {
                Name = name,
                Phones = phones.Select(ph => new PhoneViewModel()
                {
                    Model = ph.Model,
                    Vendor = ph.Vendor,
                    Year = ph.Year
                })
            };

            var root = XDocument.Load(documenPath).Root;
            root.Add(new XElement("store", storeModel));
                
            root.Document.Save(documenPath);
        }
    }
}