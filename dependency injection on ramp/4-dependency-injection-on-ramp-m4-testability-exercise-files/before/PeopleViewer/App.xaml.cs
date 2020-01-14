using PeopleViewer.Presentation;
using PersonRepository.CachingDecorator;
using PersonRepository.Service;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private static void ComposeObjects()
        {
            var wrappedRepository = new ServiceRepository();
            var repository = new CachingRepository(wrappedRepository);
            var viewModel = new PeopleViewerViewModel(repository);
            Application.Current.MainWindow = new PeopleViewerWindow(viewModel);
            Application.Current.MainWindow.Title = "Unit Testing - People Viewer";
        }
    }
}
