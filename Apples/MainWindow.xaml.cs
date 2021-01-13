using System;
using System.Collections.Generic;
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

namespace Apples
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Invent> invent;
        List<Apple> apples;
        Apple apple;
        int dragIndex=-2;
        bool isPlayng = false;
        MediaPlayer player;

        public MainWindow()
        {
            InitializeComponent();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();

            player = new MediaPlayer();
            Uri uri = new Uri("c:\\1\\applevoice.mp3");

            player.Open(uri);
            player.Volume = 1;

            invent = new List<Invent>();
            apples = new List<Apple>();
            apple = new Apple();
            apple.Count = 1;

            for (int i = 0; i < 9; i++)
                apples.Add(new Apple());

            invent.Add(new Invent(Im0, La0));
            invent.Add(new Invent(Im1, La1));
            invent.Add(new Invent(Im2, La2));
            invent.Add(new Invent(Im3, La3));
            invent.Add(new Invent(Im4, La4));
            invent.Add(new Invent(Im5, La5));
            invent.Add(new Invent(Im6, La6));
            invent.Add(new Invent(Im7, La7));
            invent.Add(new Invent(Im8, La8));

            player.MediaEnded += playerEnded;
            
        }
        public  void playerEnded (object sender, EventArgs e)
        {
           // MessageBox.Show("!!");
            player.Stop();
           // player.Open(new Uri("c:\\1\\applevoice.mp3"));
            isPlayng = false;
        }
        void Drop( int index)
        {
            if (dragIndex == -2)
                return;
            if (dragIndex == -1)
            {
                apples[index].Count += 1;
 
            }
            else
            {
                if (dragIndex != index)
                {
                    apples[index].Count += apples[dragIndex].Count;
                    apples[dragIndex].Count = 0;
                }
                Show(dragIndex);
            }
            dragIndex = -2;
            Show(index);
            
        }

        void Show (int index)
        {
            invent[index].InvLabel.Content = apples[index].Count.ToString();
            if (apples[index].Count > 0)
                invent[index].InvImage.Source =new BitmapImage (new Uri (apples[index].FullPath));
            else
                invent[index].InvImage.Source = new BitmapImage(new Uri(apples[index].EmptyPath));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image buffer = (Image)sender;
            int tag = Convert.ToInt32(buffer.Tag);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                dragIndex = tag;
            }
            else if(e.RightButton== MouseButtonState.Pressed)
            {
                 if (tag>=0)
                {
                    if (apples[tag].Count > 0)
                    {
                        apples[tag].Count -= 1;

                        if (isPlayng == false)
                        {
                            isPlayng = true;
                            player.Play();
                        }
                    }
                    Show(tag);
                }
            }
           
        }

        private void Im_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image buffer = (Image)sender;
            int tag = Convert.ToInt32(buffer.Tag);
            Drop (tag);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
            apples.Clear();
            for (int i = 0; i < 9; i++)
            {
                apples.Add(new Apple());
                Show(i);
            }
        }
    }
}
