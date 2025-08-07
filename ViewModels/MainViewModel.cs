using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;
using WpfLedApp.Models;

namespace WpfLedApp.ViewModels
{
    /// <summary>
    /// メインウィンドウのViewModelです。
    /// MVVMツールキットのObservableObjectを継承することで、
    /// INotifyPropertyChangedの実装が不要になります。
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        // LEDの状態を管理するモデルのインスタンス
        private readonly LedModel _ledModel;

        // MVVMツールキットのObservableProperty属性を使用
        // プロパティ変更通知が自動的に実装されます。
        [ObservableProperty]
        private SolidColorBrush _ledColor;

        public MainViewModel()
        {
            _ledModel = new LedModel();
            UpdateLedColor();
        }

        // MVVMツールキットのRelayCommand属性を使用
        // このメソッドから自動的にICommandが生成されます。
        [RelayCommand]
        private void ToggleLed()
        {
            _ledModel.IsOn = !_ledModel.IsOn;
            UpdateLedColor();
        }

        /// <summary>
        /// _ledModel.IsOnの状態に基づいてLedColorプロパティを更新します。
        /// </summary>
        private void UpdateLedColor()
        {
            LedColor = _ledModel.IsOn ? Brushes.Green : Brushes.Gray;
        }
    }
}
