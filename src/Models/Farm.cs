using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models {
    public class Farm {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
        public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();
        public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();
        public List<DuckHouse> DuckHouses { get; } = new List <DuckHouse>();

        public List<IPlantable> PlantFields { get; } = new List <IPlantable>();

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
        public void AddPlowedField(PlowedField field) {
            PlowedFields.Add(field);
            PlantFields.Add(field);
            Console.WriteLine("A new plowed field has been created.");
            Thread.Sleep(2000);
        }
        public void AddNaturalField(NaturalField field) {
            NaturalFields.Add(field);
            PlantFields.Add(field);
            Console.WriteLine("A new natural field has been created.");
            Thread.Sleep(2000);
        }

        public void AddChickenHouse(ChickenHouse house) {
            ChickenHouses.Add(house);
            Console.WriteLine("A new chicken house has been created.");
            Thread.Sleep(2000);
        }

        public void AddDuckHouse(DuckHouse house) {
            DuckHouses.Add(house);
            Console.WriteLine("A new duck house has been created.");
            Thread.Sleep(2000);
        }

        public override string ToString() {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));

            NaturalFields.ForEach(nf => report.Append(nf));

            PlowedFields.ForEach(pf => report.Append(pf));

            ChickenHouses.ForEach(ch => report.Append(ch));

            DuckHouses.ForEach(dh => report.Append(dh));

            return report.ToString();
        }
    }
}