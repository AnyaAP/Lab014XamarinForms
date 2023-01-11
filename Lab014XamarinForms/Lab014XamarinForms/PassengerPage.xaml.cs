using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab014XamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerPage : ContentPage
    {
        Passenger Passenger0 { get; set; }
        public PassengerPage()
        {
            InitializeComponent();
        }
        PassengerService passengerService;
        public PassengerPage(PassengerService passengerS)
        {
            InitializeComponent();
            passengerService = passengerS;
            this.BindingContext = this;
        }
        private void SavePassenger(object sender, EventArgs e)
        {
            Passenger0 = (Passenger)BindingContext;

            if (Passenger0.Id != 0)
            {
                _ = passengerService.Update(Passenger0);
                this.Navigation.PopAsync();
            }
            else
            {
                _ = passengerService.Add(Passenger0);
                this.Navigation.PopAsync();
            }
        }
        private void DeletePassenger(object sender, EventArgs e)
        {
            Passenger0 = (Passenger)BindingContext;
            if (Passenger0 != null)
            {
                _ = passengerService.Delete(Passenger0.Id);
            }
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}