using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Scorer.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    