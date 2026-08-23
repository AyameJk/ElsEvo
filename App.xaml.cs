using System.Windows;
using ElsEvo.Properties;

namespace ElsEvo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeManager.AplicarTemaSalvo();
            InicializacaoComWindows.Aplicar(Settings.Default.IniciarComWindows);

            var janelaPrincipal = new MainWindow();
            MainWindow = janelaPrincipal;

            if (Settings.Default.StartHidden)
            {

                janelaPrincipal.WindowState = WindowState.Minimized;
                janelaPrincipal.Show();
                janelaPrincipal.Hide();
            }
            else
            {
                janelaPrincipal.Show();
            }
        }
    }
}
