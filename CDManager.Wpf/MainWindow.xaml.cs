using CdManager.Model;
using CDManager.Wpf.Windows;
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

namespace CDManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cd> _cds;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = listBoxCds.SelectedItem as Cd;

            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine CD auswählen!");
                return;
            }
            AddCdWindow addCdWindow = new AddCdWindow(selectedCd);
            addCdWindow.ShowDialog();
            Repository repo = Repository.GetInstance();
            _cds = repo.GetAllCds();

            listBoxCds.ItemsSource = _cds;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Cd selectedCd = listBoxCds.SelectedItem as Cd;

            if (selectedCd == null)
            {
                MessageBox.Show("Sie müssen eine CD auswählen!");
                return;
            }
            Repository repo = Repository.GetInstance();
            repo.Remove(selectedCd);
            _cds = repo.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow(null);
            addCdWindow.ShowDialog();

            Repository repo = Repository.GetInstance();
            _cds = repo.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repo = Repository.GetInstance();
            _cds = repo.GetAllCds();
            listBoxCds.ItemsSource = _cds;
        }
    }
}
