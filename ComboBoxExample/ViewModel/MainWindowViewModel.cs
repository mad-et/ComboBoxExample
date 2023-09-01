using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ComboBoxExample.Services;
using Prism.Mvvm;
using System.Collections.Generic;

namespace ComboBoxExample.ViewModel
{
    internal class MainWindowViewModel : BindableBase
    {

        private ExternalCommandData _commandData;

        public MainWindowViewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            Categories = Utils.GetCategoties(commandData);
            Elements = new List<Element>();
        }

        #region Categories       
        public List<Category> Categories { get; set; }
       
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                SetProperty(ref selectedCategory, value);
                Elements = Utils.GetElements(_commandData, SelectedCategory);
            }
        }
        #endregion

        #region Types       
        public List<Element> Elements { get; set; }        
        public Element SelectedElement { get; set; }
        #endregion
    }
}
