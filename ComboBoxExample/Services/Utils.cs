using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxExample.Services
{
    internal class Utils
    {
        public static List<Category> GetCategoties(ExternalCommandData commandData)
        {
            List<Category> result=new List<Category>();
            Categories categories = commandData.Application.ActiveUIDocument.Document.Settings.Categories;
            foreach(Category category in categories)
            {
                result.Add(category);
            }
            return result;
        }

        public static List<Element> GetElements(ExternalCommandData commandData, Category selectedCategory)
        {
            if (selectedCategory == null)
                return new List<Element>();
            Document doc = commandData.Application.ActiveUIDocument.Document;
            return new FilteredElementCollector(doc).OfCategoryId(selectedCategory.Id).ToElements().ToList();
        }
    }
}
