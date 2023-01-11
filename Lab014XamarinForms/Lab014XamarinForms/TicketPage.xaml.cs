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
    public partial class TicketPage : ContentPage
    {
        Ticket Ticket0 { get; set; }
        public TicketPage()
        {
            InitializeComponent();
        }
        TicketService ticketService;
        public TicketPage(TicketService ticketS)
        {
            InitializeComponent();
            ticketService = ticketS;
            this.BindingContext = this;
        }
        private void SaveTicket(object sender, EventArgs e)
        {
            Ticket0 = (Ticket)BindingContext;

            if (Ticket0.Id != 0)
            {
                _ = ticketService.Update(Ticket0);
                this.Navigation.PopAsync();
            }
            else
            {
                _ = ticketService.Add(Ticket0);
                this.Navigation.PopAsync();
            }
        }
        private void DeleteTicket(object sender, EventArgs e)
        {
            Ticket0 = (Ticket)BindingContext;
            if (Ticket0 != null)
            {
                _ = ticketService.Delete(Ticket0.Id);
            }
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}