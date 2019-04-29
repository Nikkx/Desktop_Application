using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        private FlightBoardModel model;

        public FlightBoardViewModel(FlightBoardModel model)
        {
            this.model = model;
            this.model.PropertyChanged += PropChanged;
            /*model.PropertyChanged += (string propName,double val) =>
            {
                PropertyInfo propertyInfo = this.GetType().GetProperty(propName);
                propertyInfo.SetValue(this, val);
            };
            model.PropertyChanged += (string propName, double val) =>
            {
                Console.WriteLine(propName);
            };*/
        }

        private void PropChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperty(e.PropertyName);
            if(e.PropertyName.Equals("Lon"))
                propertyInfo.SetValue(this,model.Lon);
            if(e.PropertyName.Equals("Lat"))
                propertyInfo.SetValue(this, model.Lat);
        }

        private double lon;
        public double Lon
        {
            get { return lon; }
            set
            {
                lon = model.Lon;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = model.Lat;
                NotifyPropertyChanged("Lat");
            }
        }

    }
}
