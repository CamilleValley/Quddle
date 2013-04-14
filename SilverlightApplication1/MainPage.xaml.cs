using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Threading;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();

                service.GetLocationsCompleted +=
                    new EventHandler<ServiceReference1.GetLocationsCompletedEventArgs>(service_GetDateCompleted);

                service.GetLocationsAsync();
            }
            catch (Exception ex) {MessageBox.Show(ex.Message);}
        }

        private void service_GetDateCompleted(object sender,
                        ServiceReference1.GetLocationsCompletedEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
