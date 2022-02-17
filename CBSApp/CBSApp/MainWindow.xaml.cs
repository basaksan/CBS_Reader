using System.Windows;
using CBSApp.Common;
using CBSApp.Data;

namespace CBSApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GraduateData data;

        public MainWindow()
        {
            InitializeComponent();
            data = new GraduateData();
            data.Load();
            this.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var cbs = new CbsClient();
            //foreach(var x in cbs.GetCatalog())
            //{
            //    ResultRichTextBox.AppendText(x + Environment.NewLine);
            //}
        }
    }
}
