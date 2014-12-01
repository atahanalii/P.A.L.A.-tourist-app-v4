using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Windows.Storage;
using Roskide_Design.Model;
using Roskide_Design.Properties;

namespace Roskide_Design.ViewModel
{
    class resturant : INotifyPropertyChanged
    {
        private ObservableCollection<HotelModel> _elephants;
        private HotelModel _selectedElephantModel;
        private HotelModel _newElephaneModel;
        private ICommand _addNewElephant;
        private ICommand _removeSelectedElephant;
        private ObservableCollection<RatingModel> _zooModels;
        private RatingModel _selectedZoo;
        private ICommand _editElephantName;

        public resturant()
        {
             #region create ZooModels
            //_zooModels = new ObservableCollection<ZooModel>();
            //ZooModel z1 = new ZooModel(){ImageUrl = "/Assets/cphElephant.jpg", City = "Copenhagen", Name = "Copenhagen Zoo", Elephants = new List<ElephantModel>()};
            //ZooModel z2 = new ZooModel() {ImageUrl = "/Assets/odenseElphant.jpg",City = "Odense", Name = "Odense Zoo", Elephants = new List<ElephantModel>() };
            //_zooModels.Add(z1);
            //_zooModels.Add(z2);

            //Load XML;
            LoadZooModels();

            #endregion
            #region create elephants
            //ElephantModel e1 = new ElephantModel();
            //e1.EarSize = "Big";
            //e1.Name = "Monty";
            //e1.imageURL = "/Assets/whiteElephant.jpg";

            //ElephantModel e2 = new ElephantModel();
            //e2.EarSize = "Small";
            //e2.Name = "Python";
            //e2.imageURL = "/Assets/elephants-9a.jpg";

            //// short way of doing the same as above
            //ElephantModel e3 = new ElephantModel(){EarSize = "small", Name = "Ebbe", NumberOfChildren = 2, Weight = 78, imageURL = ""};

            //ZooModels[0].Elephants.Add(e1);
            //ZooModels[0].Elephants.Add(e2);

            //ZooModels[1].Elephants.Add(e3);

            //Load XML
            LoadElephantModels();

            //SelectedZoo = ZooModels[0];
            #endregion

            _newElephaneModel = new HotelModel();
            _addNewElephant = new RelayCommand(AddElephant);
            _removeSelectedElephant = new RelayCommand(RemoveElephant);
            //_editElephantName = new RelayCommand(EditElephantNameCommand);
        }

        private async void LoadElephantModels()
        {
            //try to load elephants xml from local storage
            StorageFile file = null;
            try
            {
                file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("Resturant.xml");
            }
            catch (Exception)
            {
            }

            // if it fails use assets  folder
            if (file == null)
            {
                StorageFolder installationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                string xmlfile = @"Assets\Xml\Hotels.xml";
                file = await installationFolder.GetFileAsync(xmlfile);
            }


            Stream elephantStream = await file.OpenStreamForReadAsync();
            XDocument elephantDocument = XDocument.Load(elephantStream);

            IEnumerable<XElement> elephantList = elephantDocument.Descendants("hotel");


            foreach (XElement xElement in elephantList)
            {
                HotelModel e = new HotelModel();
                e.Name = xElement.Element("name").Value;
                e.Zoo = xElement.Element("zoo").Value;
                e.Weight = Convert.ToInt32(xElement.Element("count").Value);
                e.imageURL = xElement.Element("imageurl").Value;
                e.EarSize = xElement.Element("discription").Value;

                //find the correct zoo and add the elephant to it!
                foreach (RatingModel zooModel in ZooModels)
                {
                    if (zooModel.Name.Equals(e.Zoo))
                    {
                        zooModel.Elephants.Add(e);
                    }
                }

            }
            OnPropertyChanged("Elephants");
        }

        /// <summary>
        /// Loads ZooModels
        /// </summary>
        private async void LoadZooModels()
        {
            StorageFolder installationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            string xmlfile = @"Assets\Xml\ResturantRating.xml";
            StorageFile file = await installationFolder.GetFileAsync(xmlfile);

            Stream zooStream = await file.OpenStreamForReadAsync();
            XDocument zooModelDocument = XDocument.Load(zooStream);

            IEnumerable<XElement> zooModelsList = zooModelDocument.Descendants("zoomodel");

            ZooModels = new ObservableCollection<RatingModel>();

            foreach (XElement xElement in zooModelsList)
            {
                ZooModels.Add(new RatingModel()
                {
                    Name = xElement.Element("name").Value,
                    ImageUrl = xElement.Element("imageurl").Value,
                    Elephants = new List<HotelModel>()
                });
            }

            OnPropertyChanged("ZooModels");

        }

        //private void EditElephantNameCommand()
        //{
        //    SelectedElephantModel.Name = "New Name";
        //    OnPropertyChanged("SelectedElephantModel");
        //    OnPropertyChanged("SelectedZoo");
        //}

        public ICommand EditElephantName
        {
            get { return _editElephantName; }
            set { _editElephantName = value; }
        }

        public RatingModel SelectedZoo
        {
            get { return _selectedZoo; }
            set
            {
                _selectedZoo = value;
                OnPropertyChanged("SelectedZoo");
            }
        }

        public ObservableCollection<RatingModel> ZooModels
        {
            get { return _zooModels; }
            set { _zooModels = value; }
        }

        private void RemoveElephant()
        {
            _elephants.Remove(_selectedElephantModel);
        }

        //executed by the a relaycommand (addNewElephant)
        private void AddElephant()
        {
            _elephants.Add(_newElephaneModel);
            OnPropertyChanged("Elephants");
        }

        public ICommand RemoveSelectedElephant
        {
            get { return _removeSelectedElephant; }
            set { _removeSelectedElephant = value; }
        }

        public ICommand AddNewElephant
        {
            get { return _addNewElephant; }
            set { _addNewElephant = value; }
        }

        public HotelModel NewElephaneModel
        {
            get { return _newElephaneModel; }
            set { _newElephaneModel = value; }
        }

        public HotelModel SelectedElephantModel
        {
            get { return _selectedElephantModel; }
            set
            {
                _selectedElephantModel = value;

                // this line tells the UI (and the rest of the system) that a property changed
                OnPropertyChanged("SelectedElephantModel");
            }
        }

        public ObservableCollection<HotelModel> Elephants
        {
            get { return _elephants; }
            set { _elephants = value; }
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
}
