using System;
using System.Windows;

namespace ProjectCleaner
{
    public partial class DirectoryToRemoveDialog : Window
    {
        private Action<string> ok;

        public DirectoryToRemoveDialog(Action<string> Ok)
        {
            InitializeComponent();

            this.ok = Ok;
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DirectoryToRemoveTextBox.Text))
            {
                this.ok.Invoke(DirectoryToRemoveTextBox.Text);
                this.Close();
            }
            else
            {
                MessageTextBlock.Text = "Please, enter a name of directory to remove";
            }
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
