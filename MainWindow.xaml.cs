using System.Windows;
using WpfLedApp.ViewModels;

namespace WpfLedApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // データコンテキストをMainViewModelの新しいインスタンスに設定します。
            // これにより、XAMLのバインディングがViewModelのプロパティとコマンドに接続されます。
            this.DataContext = new MainViewModel();
        }
    }
}
