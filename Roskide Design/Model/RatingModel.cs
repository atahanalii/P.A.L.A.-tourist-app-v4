using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roskide_Design.Model
{
    class RatingModel : INotifyCollectionChanged
    {
        private String _imageUrl;
        private List<HotelModel> _elephants;
        public String Name { get; set; }
        public String City { get; set; }

        public List<HotelModel> Elephants
        {
            get { return _elephants; }
            set { _elephants = value; }
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public String ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
