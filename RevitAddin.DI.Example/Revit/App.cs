using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.DI.Example.Revit.Commands;
using RevitAddin.DI.Example.Services;
using ricaun.Revit.DI;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.DI.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("RevitAddin.DI.Example");
            ribbonPanel.CreatePushButton<Commands.Command>()
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<Command<RevitMessageCommand>>("Message")
                .SetLargeImage("Resources/Revit.ico");

            ribbonPanel.CreatePushButton<Command<RevitDocumentCommand>>("Document")
                .SetLargeImage("Resources/Revit.ico");

            Host.Container.AddRevitSingleton(application);
            Host.Container.AddScoped<IMessageService, MessageService>();
            Host.Container.AddScoped<IDocumentService, DocumentService>();

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();

            Host.Container.Dispose();

            return Result.Succeeded;
        }
    }

}