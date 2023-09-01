using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ComboBoxExample.View;
using ComboBoxExample.ViewModel;

namespace ComboBoxExample
{
    [Transaction(TransactionMode.Manual)]
    public class Cmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(commandData);
            mainWindow?.Show();
            return Result.Succeeded;
        }
    }
}
