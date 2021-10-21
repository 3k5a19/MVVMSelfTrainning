using betweenViewModelandModel.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;

namespace betweenViewModelandModel.ViewModels
{
    public class BetweenViewModelandModel : BindableBase
    {
        Model _model;

        // チェック状態
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        // メッセージ
        private string _message = "Message";
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public DelegateCommand ExecuteCommand { get; }

        // コンストラクタ
        public BetweenViewModelandModel()
        {
            // Modelのインスタンス・初期値を生成
            _model = new Model();
            _model.IsChecked = this.IsChecked;
            _model.Message = this.Message;

            // ボタン押下時のコマンドを生成
            ExecuteCommand = new DelegateCommand(
             () => _model.Execute(),
             () => true
             );

            // プロパティ変更のイベントを追加
            _model.PropertyChanged += ModelPropertyChanged;
            PropertyChanged += ViewModelPropertyChanged;
        }


        // Modelのプロパティ変更
        // ModelのプロパティをViewModelのプロパティにセットする
        private void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_model.Message))
            {
                Message = _model.Message;
            }
        }

        // ViewModelのプロパティ変更
        // ViewModelのプロパティをModelのプロパティにセットする
        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChecked))
            {
                _model.IsChecked = IsChecked;
            }
        }
    }
}
