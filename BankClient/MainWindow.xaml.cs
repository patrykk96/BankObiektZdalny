using Bank;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankLogic bank;
        string token; 

        public MainWindow()
        {
            InitializeComponent();
            gridLogin.Visibility = Visibility.Visible;
            ClearAll();
            gridClientPanel.Visibility = Visibility.Hidden;

            HttpClientChannel channel = new HttpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(BankLogic), "http://localhost:12345/Bank");
            bank = new BankLogic();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            
            string account = textboxAccountNumber.Text;
            string pin = textboxPin.Password;
            token = bank.Authorize(account, pin);
            if (token.Length == 0)
            {
                labelLoginError.Content = "Podane dane logowania są niepoprawne";
            }
            else
            {
                ClearAll();
                gridLogin.Visibility = Visibility.Hidden;
                gridClientPanel.Visibility = Visibility.Visible;
                RefreshBalance();
                labelCurrency.Content = bank.GetCurrency(token);
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            bank.Bye(token);
            ClearAll();
            gridLogin.Visibility = Visibility.Visible;
            gridClientPanel.Visibility = Visibility.Hidden;
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshBalance();
        }

        private void RefreshBalance()
        {
            string balance = bank.GetBalance(token).ToString();
            labelAccountBalance.Content = balance;
        }

        private void ButtonDeposit_Click(object sender, RoutedEventArgs e)
        {
            string amount = textboxAmount.Text.Replace(".", ",");
            bool number = double.TryParse(amount, out double result);

            if (!number)
            {
                labelClientError.Content = "Podana kwota jest niepoprawna";
            }
            else
            {
                labelClientError.Content = "";
                double value = double.Parse(amount, CultureInfo.CurrentCulture);
                bank.Deposit(token, value);
                RefreshBalance();
            }
        }

        private void ButtonWithdraw_Click(object sender, RoutedEventArgs e)
        {
            string amount = textboxAmount.Text.Replace(".", ",");
            bool number = double.TryParse(amount, out double result);

            if (!number)
            {
                labelClientError.Content = "Podana kwota jest niepoprawna";
            }
            else
            {
                labelClientError.Content = "";
                double value = double.Parse(amount, CultureInfo.CurrentCulture);
                bool success = bank.Withdraw(token, value);

                if (success)
                {
                    RefreshBalance();
                }
                else
                {
                    labelClientError.Content = "Nie udało się dokonać wypłacenia środków";
                }
            }
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            string amount = textboxAmount.Text.Replace(".", ",");
            bool number = double.TryParse(amount, out double result);

            if (!number)
            {
                labelClientError.Content = "Podana kwota jest niepoprawna";
            }
            else
            {
                labelClientError.Content = "";
                double value = double.Parse(amount, CultureInfo.CurrentCulture);
                string account = textboxTargetNumber.Text;
                string success = bank.Withdraw(token, account, value);

                if (success.Length != 0)
                {
                    labelClientError.Content = "";
                    MessageBox.Show(success, "Informacja");
                    RefreshBalance();
                }
                else
                {
                    labelClientError.Content = "Nie udało się dokonać przelewu";
                }
            }
        }

        private void ClearAll()
        {
            labelLoginError.Content = "";
            labelAccountBalance.Content = "";
            labelClientError.Content = "";
            labelCurrency.Content = "";
            textboxAccountNumber.Text = "";
            textboxAmount.Text = "";
            textboxPin.Password = "";
            textboxTargetNumber.Text = "";
        }
    }
}
