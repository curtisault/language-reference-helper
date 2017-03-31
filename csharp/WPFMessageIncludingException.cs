class WPFMessageService
{
    static void ShowMessage(string text, string caption, MessageType messageType)
    {
        // TODO: Choose MessageBoxButton and MessageBoxImage based on MessageType received
        MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
    }


    public void ShowErrorDialog(string text, string caption)
    {
        string messageBoxText = text + "\n\nDo you want to copy to clipboard?";
        MessageBoxButton button = MessageBoxButton.YesNoCancel;
        MessageBoxImage icon = MessageBoxImage.Error;

        MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

        // Process message box results
        switch (result)
        {
            case MessageBoxResult.Yes:
                // User pressed Yes button
                Thread thread = new Thread((() => Clipboard.SetText(text)));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                break;
            case MessageBoxResult.No:
                // User pressed No button
                // ...
                break;
            case MessageBoxResult.Cancel:
                // User pressed Cancel button
                // ...
                break;
        }
    }
}
