using Autodesk.Revit.UI;
using RevitAddin.DI.Example.Services;

namespace RevitAddin.DI.Example.Revit.Commands
{
    public class RevitMessageCommand : ICommand
    {
        private readonly IMessageService messageService;
        private readonly UIApplication uiapp;

        public RevitMessageCommand(IMessageService messageService, UIApplication uiapp)
        {
            this.messageService = messageService;
            this.uiapp = uiapp;
        }

        public void Execute()
        {
            messageService.Show(uiapp.Application.VersionName, "Like this video!");
        }
    }

}
