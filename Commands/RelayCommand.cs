using System;
using System.Windows.Input;

namespace WpfLedApp.Commands
{
    /// <summary>
    /// ICommandインターフェースを実装する汎用的なコマンドクラスです。
    /// ViewModelのメソッドをViewから呼び出すために使用されます。
    /// </summary>
    public class RelayCommand : ICommand
    {
        // コマンドが実行されたときに呼び出されるActionデリゲート
        private readonly Action<object> _execute;
        // コマンドが実行可能かどうかを判断するFuncデリゲート (オプション)
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// RelayCommandの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="execute">コマンドが実行されたときに呼び出されるデリゲート。</param>
        /// <param name="canExecute">コマンドが実行可能かどうかを判断するデリゲート (省略可能)。</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// コマンドが現在の状態で実行可能かどうかを定義します。
        /// </summary>
        /// <param name="parameter">コマンドの実行に使用されるデータ。</param>
        /// <returns>コマンドが実行可能な場合はtrue、そうでない場合はfalse。</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        /// <summary>
        /// コマンドが実行可能かどうかに影響を与える変更が発生したときに発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 現在のコマンドターゲットでコマンドを実行します。
        /// </summary>
        /// <param name="parameter">コマンドの実行に使用されるデータ。</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
