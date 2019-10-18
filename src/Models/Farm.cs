using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;
using System.Threading;

namespace Trestlebridge.Models {
    public class Farm {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T>(IResource resource, int index) {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString()) {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing) resource);
                    break;
                default:
                    break;
            }
        }

        public void AddGrazingField(GrazingField field) {
            GrazingFields.Add(field);
            // Added the Console.WriteLine and added a 2 second delay before showing the main menu.
            Console.WriteLine("A new grazing field has been created.");
            Thread.Sleep(2000);
        }

        public override string ToString() {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));

            return report.ToString();
        }
    }
}