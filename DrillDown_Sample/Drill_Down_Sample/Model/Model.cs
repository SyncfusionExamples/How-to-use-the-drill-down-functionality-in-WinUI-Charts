using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drill_Down_Sample
{
    public class Model
    {
        public string Type { get; set; }

        public double Value { get; set; }

        public Model(string type, double value)
        {
            Type = type;
            Value = value;
        }

        public Model(string type, double value, ObservableCollection<Model> collections)
        {
            Type = type;
            Value = value;
            Collections = collections;
        }

        public ObservableCollection<Model> Collections
        {
            get;
            set;
        }
    }
}
