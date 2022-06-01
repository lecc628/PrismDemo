using System;

using Prism.Services.Dialogs;

using PrismDemo.Core.Names;

namespace PrismDemo.Core.Dialogs
{
    public static class IDialogServiceExtensions
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, Action<IDialogResult> callback)
        {
            var parameters = new DialogParameters
            {
                { "Message", message }
            };

            dialogService.ShowDialog(ApplicationViewNames.MessageDialogView, parameters, callback);
        }
    }
}
