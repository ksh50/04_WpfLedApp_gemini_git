using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using WpfLedApp.Models; // LedModelを使用するため
using WpfLedApp.Commands; // RelayCommandを使用するため

namespace WpfLedApp.ViewModels
{
    /// <summary>
    /// メインウィンドウのViewModelです。
    /// Viewに表示するデータとコマンドを提供します。
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // LEDの状態を管理するモデルのインスタンス
        private LedModel _ledModel;

        // LEDの色をViewに公開するプロパティ
        private SolidColorBrush _ledColor;
        public SolidColorBrush LedColor
        {
            get { return _ledColor; }
            set
            {
                if (_ledColor != value)
                {
                    _ledColor = value;
                    OnPropertyChanged(nameof(LedColor)); // Viewに変更を通知
                }
            }
        }

        // LEDの状態を切り替えるコマンド
        public ICommand ToggleLedCommand { get; private set; }

        public MainViewModel()
        {
            _ledModel = new LedModel(); // モデルを初期化
            UpdateLedColor(); // 初期LED色を設定 (消灯)
            ToggleLedCommand = new RelayCommand(ToggleLed); // コマンドを初期化
        }

        /// <summary>
        /// LEDの状態を切り替えるメソッドです。
        /// ボタンが押されたときにこのメソッドが実行されます。
        /// </summary>
        private void ToggleLed(object parameter)
        {
            _ledModel.IsOn = !_ledModel.IsOn; // LEDの状態を反転
            UpdateLedColor(); // LEDの色を更新
        }

        /// <summary>
        /// _ledModel.IsOnの状態に基づいてLedColorプロパティを更新します。
        /// </summary>
        private void UpdateLedColor()
        {
            // LEDが点灯していればGreen、消灯していればGrayを設定
            LedColor = _ledModel.IsOn ? Brushes.Green : Brushes.Gray;
        }

        // INotifyPropertyChangedインターフェースの実装
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変更されたときにViewに通知するためのヘルパーメソッドです。
        /// </summary>
        /// <param name="propertyName">変更されたプロパティの名前。</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
