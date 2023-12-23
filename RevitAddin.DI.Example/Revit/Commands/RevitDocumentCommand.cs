using Autodesk.Revit.UI;
using RevitAddin.DI.Example.Services;

namespace RevitAddin.DI.Example.Revit.Commands
{
    public class RevitDocumentCommand : ICommand
    {
        private readonly IMessageService messageService;
        private readonly UIApplication uiapp;
        private readonly IDocumentService documentService;

        public RevitDocumentCommand(IMessageService messageService, UIApplication uiapp, IDocumentService documentService)
        {
            this.messageService = messageService;
            this.uiapp = uiapp;
            this.documentService = documentService;
        }

        public void Execute()
        {
            messageService.Show(uiapp.Application.VersionName, $"The document with the name '{documentService.GetDocument()?.Title}'.");
        }
    }

}
