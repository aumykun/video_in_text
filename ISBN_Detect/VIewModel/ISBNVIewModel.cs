using System.Collections.ObjectModel;
namespace ISBN_Detect.VIewModel
{
    /// <summary>
    /// This class was created for MVVM model features such as creating instances of ISBN model class.
    /// Is empty because is not necessary to store data in suck an app/
    /// </summary>
    class ISBNVIewModel
    {
        static ObservableCollection<Model.ISBNModel> ISBNs
        {
            get; set;
        } = null;
       
    }
}
