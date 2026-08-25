using System.Threading;
using System.Windows;
using ElsEvo.Properties;

namespace ElsEvo
{
    public partial class App : Application
    {
        // Mutex nomeado igual ao AppMutex do ElsEVO.iss ("ElsEvo_MutexPrincipal").
        // Sem isso, o Inno Setup não consegue detectar via Restart Manager que o
        // ElsEvo está rodando quando alguém abre o instalador manualmente com o
        // app aberto -- o AppMutex no .iss só funciona se ALGUÉM realmente criar
        // esse mutex em runtime. Portado do canal beta.
        private static Mutex? _mutexPrincipal;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegistroLog.Registrar("Aplicativo iniciado");

            _mutexPrincipal = new Mutex(initiallyOwned: true, name: "ElsEvo_MutexPrincipal");

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

        protected override void OnExit(ExitEventArgs e)
        {
            RegistroLog.Registrar("Aplicativo encerrado");
            _mutexPrincipal?.ReleaseMutex();
            _mutexPrincipal?.Dispose();
            base.OnExit(e);
        }
    }
}
