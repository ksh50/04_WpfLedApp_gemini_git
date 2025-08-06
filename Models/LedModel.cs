namespace WpfLedApp.Models
{
    /// <summary>
    /// LEDランプの状態を表すモデルクラスです。
    /// </summary>
    public class LedModel
    {
        // LEDが点灯しているかどうかを示すプロパティ
        public bool IsOn { get; set; }

        public LedModel()
        {
            // 初期状態は消灯（false）に設定します。
            IsOn = false;
        }
    }
}
