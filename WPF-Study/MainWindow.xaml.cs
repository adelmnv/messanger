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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public List<string> GroupChat { get; set; }

        public Contact(string s1, string s2, string s3, string s4, string s5, List<string>p)
        {
            GroupChat = new List<string>();
            Name = s1; Status = s2; Group = s3; Desc = s4;  Img = s5; GroupChat = p; 
        }
        public Contact() { }

    }
    public class MyContacts
    {
        ObservableCollection<Contact> contacts = null;
        public MyContacts()
        {
            contacts = new ObservableCollection<Contact>();
            contacts.Add(new Contact("Wilson", "online", "adm", "", "", new List<string>()));
            contacts.Add(new Contact("Christopher", "online", "pro", "Siliconplus SEO Work", "https://cdn-icons-png.flaticon.com/512/3135/3135715.png", new List<string>()));
            contacts.Add(new Contact("Edward", "online", "pro", "ABM data entry", "", new List<string>()));
            contacts.Add(new Contact("Campbell", "online", "sal", "", "", new List<string>()));
            contacts.Add(new Contact("Robinson", "offline", "ou", "Silverstrip Fixes", "https://cdn-icons-png.flaticon.com/512/2202/2202090.png", new List<string>()));
            contacts.Add(new Contact("Marketing", "", "chr", "4 Members", "https://cdn-icons-png.flaticon.com/512/1256/1256650.png", new List<string>() { "Wilson", "Edward", "Robinson", "Campbell" }));
            contacts.Add(new Contact("On My Trip Projects", "", "chr", "3 Members", "https://cdn-icons-png.flaticon.com/512/1256/1256650.png", new List<string>() { "Christopher", "Campbell", "Wilson" }));
            contacts.Add(new Contact("", "", "", "", "", new List<string>()));
        }

        public ObservableCollection<Contact> GetData()
        {
            return contacts;
        }
        public int Count()
        {
            return contacts.Count;
        }
        public Contact ElementAt(int n)
        {
            return contacts[n];
        }

        public Contact Search(string n)
        {
            Contact contact = new Contact();
            foreach(Contact c in contacts)
            {
                if (c.Name == n)
                    return c;
            }
             return contact;
        }
    }

    public class Message
    {
        public Message(string msg, string user, string time, string ch)
        {
            str = msg; User = user; Time = time; Chat = ch;
        }
        public string str { get; set; }
        public string User { get; set; }
        public string Time { get; set; }
        public string Chat { get; set; }

        public Message () { }
    }


    public class Messages
    {
        ObservableCollection<Message> messages = null;
        public Messages()
        {
            messages = new ObservableCollection<Message>();
            messages.Add(new Message("Hi All", "Christopher", "15:36", "On My Trip Projects"));
            messages.Add(new Message("Tomorrow Morning, We have Demo of Evhospice.", "Christopher", "15:37", "On My Trip Projects"));
            messages.Add(new Message("Yes, Sure.", "Edward", "15:37", "On My Trip Projects"));
            messages.Add(new Message("All thing finished. Few minor changes are going which will be finished shortly.", "Campbell", "15:38", "On My Trip Projects"));
            messages.Add(new Message("Hope everything will be fine", "Me", "12:44", "On My Trip Projects"));
            messages.Add(new Message("Good Morning everyone", "Campbell", "12:36", "Marketing"));
            messages.Add(new Message("Hi Campbell", "Wilson", "12:41", "Marketing"));
            messages.Add(new Message("Are you ready for working week?", "Edward", "12:41", "Marketing"));
            messages.Add(new Message("Of course Edward!", "Robinson", "12:42", "Marketing"));
            messages.Add(new Message("I am preparing for Marketing presintation...", "Me", "12:44", "Marketing"));
            messages.Add(new Message("Hi Campbell", "Me", "09:30", "Campbell"));
            messages.Add(new Message("Morning", "Campbell", "11:41", "Campbell"));
            messages.Add(new Message("Hi Christopher", "Me", "09:30", "Christopher"));
            messages.Add(new Message("How are you?", "Christopher", "11:41", "Christopher"));
            messages.Add(new Message("Morning Edward", "Me", "09:30", "Edward"));
            messages.Add(new Message("Let's go to lunch!", "Edward", "09:30", "Edward"));
            messages.Add(new Message("Hi Wilson", "Me", "09:30", "Wilson"));
            messages.Add(new Message("What are you doing!?", "Wilson", "11:41", "Wilson"));
            messages.Add(new Message("Hi Robinson", "Me", "09:30", "Robinson"));
            messages.Add(new Message("I can't talk right now", "Robinson", "11:41", "Robinson"));
        }
        public int Count()
        {
            return messages.Count;
        }
        public Message ElementAt(int n)
        {
            return messages[n];
        }

        public Message Search(string n)
        {
            Message message = new Message();
            foreach (Message c in messages)
            {
                if (c.Chat == n)
                    return c;
            }
            return message;
        }
    }
    public partial class MainWindow : Window, Abstractions.IView
    {
        MyContacts contacts = new MyContacts();
        Contacts cn = new Contacts();
        Messages messages = new Messages();
        public MainWindow()
        {
            InitializeComponent();
            AddContacts();
            FillInformation();
            FillMessage("");
        }

        public void AddContacts()
        {
            for(int i=0; i < contacts.Count(); i++)
            {
                string s = contacts.ElementAt(i).Group;
                cn.ChooseContact += (sender, eventArgs) => SetInformation(sender);

                cn = new Contacts(contacts.ElementAt(i));
                if (s == "adm")
                SPadm.Children.Add(cn);
                else if (s == "pro")
                    SPpro.Children.Add(cn);
                else if (s == "sal")
                    SPsal.Children.Add(cn);
                else if (s == "ou")
                    SPou.Children.Add(cn);
                else if (s == "chr")
                    Schr.Children.Add(cn);
            }
        }
        private void btnAll(object sender, MouseEventArgs e)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF07AAFF"));
            all.Fill = newBrush;
            fav.Fill = new SolidColorBrush(Colors.White);
            rec.Fill = new SolidColorBrush(Colors.White);
        }

        private void btnFav(object sender, MouseEventArgs e)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF07AAFF"));
            all.Fill = new SolidColorBrush(Colors.White);
            fav.Fill = newBrush; 
            rec.Fill = new SolidColorBrush(Colors.White);
        }

        private void btnRec(object sender, MouseEventArgs e)
        {
            var newBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF07AAFF"));
            all.Fill = new SolidColorBrush(Colors.White);
            fav.Fill = new SolidColorBrush(Colors.White);
            rec.Fill = newBrush;
        }

        private void Tb_click(object sender, MouseButtonEventArgs e)
        {
            tbxValue.Text = " ";
        }

        public void SetInformation(object sender)
        {
            Grid p = (Grid)sender;
            ChatInf.Children.Clear();
            var temp = p.Children.OfType<TextBlock>().Where(x => x.Name == "ContactName");
            if (temp.First().Text != null || temp.First().Text != "")
            {
                Contact s = contacts.Search(temp.First().Text);
                if(s.Name != "" || s.Name != null)
                {
                    GroupName.Text = s.Name;
                    ChatName.Text = s.Name;
                    if(s.Img != "")
                        ChatImg.Source = new ImageSourceConverter().ConvertFromString(s.Img) as ImageSource;
                    else
                        ChatImg.Source = new ImageSourceConverter().ConvertFromString("https://cdn-icons-png.flaticon.com/512/1177/1177568.png") as ImageSource;
                    ChatRectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0885F9"));
                    if(s.Group == "chr")
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = s.Desc;
                        ChatInf.Children.Add(tb);
                        foreach (string x in s.GroupChat)
                        {
                            Rectangle r = new Rectangle();
                            r.Width = 15;
                            ChatInf.Children.Add(r);
                            Ellipse e = new Ellipse();
                            e.Width = 10; e.Height = 10;
                            if (contacts.Search(x).Status == "online")
                                e.Fill = new SolidColorBrush(Colors.LightGreen);
                            else if (contacts.Search(x).Status == "offline")
                                e.Fill = new SolidColorBrush(Colors.Gray);
                            ChatInf.Children.Add(e);
                            TextBlock y = new TextBlock();
                            y.Text = " " + x;
                            ChatInf.Children.Add(y);
                        }
                    }
                    else
                    {
                        Ellipse e = new Ellipse();
                        e.Width = 10; e.Height = 10;
                        if (s.Status == "online")
                            e.Fill = new SolidColorBrush(Colors.LightGreen);
                        else if (s.Status == "offline")
                            e.Fill = new SolidColorBrush(Colors.Gray);
                        ChatInf.Children.Add(e);
                        Rectangle r = new Rectangle();
                        r.Width = 5;
                        ChatInf.Children.Add(r);
                        TextBlock tb = new TextBlock();
                        tb.Text = s.Status;
                        ChatInf.Children.Add(tb);
                    }
                    FillMessage(s.Name);
                }
            }
        }

        public void FillInformation()
        {
            GroupName.Text = "Wilson";
            ChatName.Text = "Wilson";
            ChatImg.Source = new ImageSourceConverter().ConvertFromString("https://cdn-icons-png.flaticon.com/512/1177/1177568.png") as ImageSource;
            ChatRectangle.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0885F9"));
            Ellipse e = new Ellipse();
            e.Width = 10; e.Height = 10;
            e.Fill = new SolidColorBrush(Colors.LightGreen);
            ChatInf.Children.Add(e);
            TextBlock tb = new TextBlock();
            tb.Text = "online";
            ChatInf.Children.Add(tb);

        }
        public void FillMessage(string chat)
        {
            MessageSP.Children.Clear();
            if (chat == "")
                chat = "Wilson";
            for (int i = 0; i < messages.Count(); i++)
            {
                if (messages.ElementAt(i).Chat == chat)
                {
                    if (messages.ElementAt(i).User != "Me")
                        MessageSP.Children.Add(NewLeftMessage(messages.ElementAt(i)));
                    else
                        MessageSP.Children.Add(NewRightMessage(messages.ElementAt(i)));
                }
            }

        }
        public MessageLeft NewLeftMessage(Message msg)
        {
            MessageLeft temp = new MessageLeft();
            temp.MessageContent.Text = msg.str;
            temp.TimeTxtB.Text = msg.Time;
            temp.UserNameTxtB.Text = msg.User;
            return temp;
        }
        public MessageRight NewRightMessage(Message msg)
        {
            MessageRight temp = new MessageRight();
            temp.MessageContent.Text = msg.str;
            temp.TimeTxtB.Text = msg.Time;
            temp.UserNameTxtB.Text = msg.User;
            return temp;
        }
    }
}
