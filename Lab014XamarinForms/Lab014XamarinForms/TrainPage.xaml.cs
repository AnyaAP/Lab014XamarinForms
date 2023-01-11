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
    public partial class TrainPage : ContentPage
    {
        TrainService trainService;
        public Train Train0 { get; set; }
        public TrainPage(TrainService trainS)
        {
            InitializeComponent();
            trainService = trainS;
            this.BindingContext = this;
        }
        private void SaveTrain(object sender, EventArgs e)
        {
            Train0 = (Train)BindingContext;

            if (Train0.Id != 0)
            {
                _ = trainService.Update(Train0);
                this.Navigation.PopAsync();
            }
            else
            {
                _ = trainService.Add(Train0);
                this.Navigation.PopAsync();
            }
        }
        private void DeleteTrain(object sender, EventArgs e)
        {
            Train0 = (Train)BindingContext;
            if (Train0 != null)
            {
                _ = trainService.Delete(Train0.Id);
            }
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}