using Microsoft.WindowsAPICodePack.Dialogs;
using MvvmLib.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace ProjectCleaner
{
    public partial class MainWindow : Window
    {
        SolutionCleaner solutionCleaner;

        public MainWindow()
        {
            InitializeComponent();

            solutionCleaner = new SolutionCleaner();

            solutionCleaner.Starting += OnStarting;
            solutionCleaner.Completed += OnCompleted;
            solutionCleaner.Failed += OnFailed;

            StatusMessage.Text = "Ready";

            this.DataContext = solutionCleaner;
        }

        private void OnStarting(object sender, EventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            StatusMessage.Text = $"Cleaned {DateTime.Now.ToLongTimeString()}";
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void OnFailed(object sender, Exception e)
        {
            StatusMessage.Text = $"Clean FAILED \"{e.Message}\", {DateTime.Now.ToLongTimeString()}";
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void AddDirectoryToRemove(object sender, RoutedEventArgs e)
        {
            var dialog = new DirectoryToRemoveDialog((t) => solutionCleaner.AddDirectoryToRemove(t));
            dialog.Show();
        }

        private void RemoveDirectoryToRemove(object sender, RoutedEventArgs e)
        {
            var directoryName = DirectoriesToRemoveListView.SelectedValue;
            if (directoryName != null)
                solutionCleaner.DirectoriesToRemove.Remove(directoryName.ToString());

        }
    }

    public class SolutionCleaner : BindableBase
    {
        private string baseDirectory;
        public string BaseDirectory
        {
            get { return baseDirectory; }
            set { SetProperty(ref baseDirectory, value); }
        }

        private ObservableCollection<string> directoriesToRemove;
        public ObservableCollection<string> DirectoriesToRemove
        {
            get { return directoriesToRemove; }
        }

        private ObservableCollection<string> removedDirectories;
        public ObservableCollection<string> RemovedDirectories
        {
            get { return removedDirectories; }
        }

        public IRelayCommand SelectCommand { get; }
        public IRelayCommand AddDirectoryToRemoveCommand { get; }
        public IRelayCommand CleanCommand { get; }

        public event EventHandler Starting;

        public event EventHandler Completed;

        public event EventHandler<Exception> Failed;

        public SolutionCleaner()
        {
            directoriesToRemove = new ObservableCollection<string>
            {
                "bin",
                "obj"
            };

            removedDirectories = new ObservableCollection<string>();

            SelectCommand = new RelayCommand(() => SelectDirectory());
            AddDirectoryToRemoveCommand = new RelayCommand<string>((t) => AddDirectoryToRemove(t));

            CleanCommand = new RelayCommand(() => Clean(), () => BaseDirectory != null)
                .ObserveProperty(() => BaseDirectory);
        }

        public void AddDirectoryToRemove(string directoryName)
        {
            this.DirectoriesToRemove.Add(directoryName);
        }

        public void SelectDirectory()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                BaseDirectory = dialog.FileName;
        }

        public void Clean()
        {
            if (baseDirectory == null)
                throw new ArgumentException("A directory have to be selected");

            try
            {
                Starting?.Invoke(this, EventArgs.Empty);

                var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
                Task.Factory.StartNew(() => ParseDirectory(baseDirectory), 
                    CancellationToken.None, 
                    TaskCreationOptions.None,
                    taskScheduler).ContinueWith((t) =>
                {
                    Completed?.Invoke(this, EventArgs.Empty);
                }, taskScheduler);
            }
            catch (Exception ex)
            {
                Failed?.Invoke(this, ex);
            }
        }

        private bool IsDirectoryToRemove(string directory)
        {
            return directoriesToRemove.Contains(directory);
        }

        private void RemoveDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
                RemovedDirectories.Add(directory);
            }
        }

        public void ParseDirectories(string[] directories)
        {
            foreach (var directory in directories)
            {
                var subDirectories = Directory.GetDirectories(directory);
                if (subDirectories.Length > 0)
                    ParseDirectories(subDirectories);

                var directoryName = new DirectoryInfo(directory).Name;
                if (IsDirectoryToRemove(directoryName))
                    RemoveDirectory(directory);
            }
        }

        public void ParseDirectory(string baseDirectory)
        {
            var directories = Directory.GetDirectories(baseDirectory);
            if (directories.Length > 0)
                ParseDirectories(directories);
        }
    }
}
