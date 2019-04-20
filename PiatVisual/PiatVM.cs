using Base.Lesson_6;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PiatVisual
{
    class PiatVM : INotifyPropertyChanged
    {
        Piatnashki _piat;
        public ObservableCollection<int> Numbers { get; set; }
        //public int Prop { get; set; }
        public bool Win { get; set; }

        public delegate void GotWin();
        public event GotWin Winner;

        public PiatVM()
        {
            _piat = new Piatnashki();
            Numbers = new ObservableCollection<int>();
            foreach (var item in _piat.array)
            {
                Numbers.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Restart()
        {
            _piat.Restart();
        }
        public void Move(Key k)
        {
            switch (k)
            {
                case Key.A:
                    _piat.Move(Piatnashki.Direction.LEFT);
                    break;
                case Key.S:
                    _piat.Move(Piatnashki.Direction.DOWN);
                    break;
                case Key.D:
                    _piat.Move(Piatnashki.Direction.RIGHT);
                    break;
                case Key.W:
                    _piat.Move(Piatnashki.Direction.UP);
                    break;
                default:
                    break;
            }
            if (_piat.Win == true)
            {
                Win = true;
                Winner?.Invoke();
            }
            Numbers.Clear();
            foreach (var item in _piat.array)
            {
                Numbers.Add(item);
            }
            //Prop = Numbers[0];
            //NotifyPropertyChanged("Prop");
            NotifyPropertyChanged("Numbers");
            
            
        }

        private void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
