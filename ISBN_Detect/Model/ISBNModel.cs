using System.ComponentModel;
using System.Drawing;

namespace ISBN_Detect.Model
{
    /// <summary>
    /// Provides MVVM pattern style model for future usage.
    /// </summary>
    public class ISBNModel : INotifyPropertyChanged
    {
        private string _isbn;
        private int _id;
        private Bitmap _image;

        public string ISBN
        {
            get
            {
                return _isbn;

            }
            set
            {
                if (_isbn != value)
                {
                    _isbn = value;
                    RaisePropertyChanged("ISBN");
                }
            }
        }
        public int ID
        {
            get
            {
                return _id;

            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("ID");
                }
            }
        }
        public Bitmap Image
        {
            get
            {
                return _image;

            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Provides MVVM functional to this class. Raises event when some of the properties where changed.
        /// </summary>
        /// <param name="property">Should be one of the Models properties</param>
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
