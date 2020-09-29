using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CDManager.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
        private Cd _cd;
        public AddCdWindow(Cd cd)
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;
            _cd = cd;
        }

        private void BtnCancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_cd == null)
            {
                Repository.GetInstance().AddCd(DataContext as Cd);
            }
            Close();
        }

        private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancle.Click += BtnCancle_Click;

            if (_cd == null)
            {
                DataContext = new Cd
                {
                    AlbumTitle = "Bitte geben Sie hier den Titel ein!",
                    Artist = "Bitte geben Sie hier den Artist ein"
                };
            }
            else
            {
                DataContext = _cd;
            }
        }
    }
}
