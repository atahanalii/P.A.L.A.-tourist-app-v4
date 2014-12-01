﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Roskide_Design.Properties;

namespace Roskide_Design.Model
{
    class HotelModel : INotifyPropertyChanged
    {
        private string _earSize;
        private string _name;
        private string _imageUrl;
        private int _weight;
        private string _zoo;

        public string EarSize
        {
            get { return _earSize; }
            set
            {
                if (value.Length != 0)
                {
                    _earSize = value;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("");
            }
        }

       

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public String imageURL
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public String Zoo
        {
            get { return _zoo; }
            set { _zoo = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
