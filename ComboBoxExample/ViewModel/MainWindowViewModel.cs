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
        /// <summary>
        /// Свойство, привязанное к верхнему комбобоксу
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Выбранный элемент в верхнем комбобоксе. 
        /// Это свойство "развернули", т.е. используем не сокращенную форму типа public Category SelectedCategory { get; set; } специально, 
        /// чтобы в части set (в момент выбора значения из верхнего комбобокса),
        /// вызвать поиск элементов из категории и занести их во второй комбобокс
        /// </summary>
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

        #region Elements   
        /// <summary>
        /// Свойство, привязанное к нижнему комбобоксу
        /// </summary>
        public List<Element> Elements { get; set; }

        /// <summary>
        /// Выбранный элемент в нижнем комбобоксе.
        /// </summary>
        public Element SelectedElement { get; set; }
        #endregion
    }
}
