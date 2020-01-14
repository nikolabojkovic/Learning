using PeopleViewer.Presentation;
using PersonRepository.CachingDecorator;
using PersonRepository.CSV;
using PersonRepository.Interface;
using PersonRepository.Service;
using PersonRepository.SQL;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow.Title = "DI with Ninject - People Viewer";
        }
    }
}
