using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace WPF_Study
{
    /// <summary>
    /// Логика взаимодействия для Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl
    {
        public TextBlock tbx = new TextBlock(); 
        public Contacts(Contact p)
        {
            InitializeComponent();
            ContactName.Text = p.Name;
            if(p.Img != "")
                ContactPhoto.Source = new ImageSourceConverter().ConvertFromString(p.Img) as ImageSource;
            if (p.Desc == "")
            ContactStatus.Text = p.Status;
            else
            ContactStatus.Text = p.Desc;
            if(p.Status == "online")
                StatusImg.Fill = new SolidColorBrush(Colors.LightGreen);
            else if (p.Status == "offline")
                StatusImg.Fill = new SolidColorBrush(Colors.Gray);
        }
        public Contacts() { }

        public void Contact_Click(object sender, MouseButtonEventArgs e)
        {
            ChooseContact?.Invoke(sender, e);
        }

        public event EventHandler ChooseContact;
    }
}
