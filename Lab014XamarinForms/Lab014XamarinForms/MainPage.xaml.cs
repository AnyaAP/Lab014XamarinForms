using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab014XamarinForms
{
    public partial class MainPage : ContentPage
    {
        PassengerService passengerService = new PassengerService();
        TicketService ticketService = new TicketService();
        TrainService trainService = new TrainService();
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            trainsList.ItemsSource = await trainService.Get();
            passengersList.ItemsSource = await passengerService.Get();
            ticketsList.ItemsSource = await ticketService.Get();
        }
        private void TrainsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Train selectedTrain = e.Item as Train;
            TrainPage trainPage = new TrainPage(trainService);
            trainPage.BindingContext = selectedTrain;
            Navigation.PushAsync(trainPage);
        }

        private void CreateTrain(object sender, EventArgs e)
        {
            Train train = new Train();
            TrainPage trainPage = new TrainPage(trainService);
            trainPage.BindingContext = train;
            Navigation.PushAsync(trainPage);
        }
        private void PassengersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Passenger selectedPassenger = e.Item as Passenger;
            PassengerPage passengerPage = new PassengerPage(passengerService);
            passengerPage.BindingContext = selectedPassenger;
            Navigation.PushAsync(passengerPage);
        }
        private void CreatePassenger(object sender, EventArgs e)
        {
            Passenger passenger = new Passenger();
            PassengerPage passengerPage = new PassengerPage(passengerService);
            passengerPage.BindingContext = passenger;
            Navigation.PushAsync(passengerPage);
        }
        private void TicketsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Ticket selectedTicket = e.Item as Ticket;
            TicketPage ticketPage = new TicketPage(ticketService);
            ticketPage.BindingContext = selectedTicket;
            Navigation.PushAsync(ticketPage);
        }
        private void CreateTicket(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            TicketPage ticketPage = new TicketPage(ticketService);
            ticketPage.BindingContext = ticket;
            Navigation.PushAsync(ticketPage);
        }
    }
}
