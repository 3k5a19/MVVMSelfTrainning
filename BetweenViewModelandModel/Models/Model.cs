using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace betweenViewModelandModel.Models
{
    public class Model : BindableBase
    {
        // チェック状態
        public bool IsChecked { get; set; }

        // メッセージ
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        // サンプルのメソッド
        public void Execute()
        {
            if (IsChecked)
            {
                Message = "チェック有りで実行しました。";
            }
            else
            {
                Message = "チェック無しで実行しました。";
            }
        }
    }
}
