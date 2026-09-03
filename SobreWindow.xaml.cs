using System.Windows;

namespace ElsEvo
{
    public partial class SobreWindow : Window
    {
        public SobreWindow()
        {
            InitializeComponent();
            ThemeManager.AplicarTemaSalvo();

            SourceInitialized += (_, _) =>
                BarraTituloNativa.AplicarTema(this, !Properties.Settings.Default.TemaClaro);

            ThemeManager.TemaMudou += AoTemaMudar;
            Closed += (_, _) => ThemeManager.TemaMudou -= AoTemaMudar;

            AplicarIdioma();

            BadgeBeta.Visibility = Visibility.Collapsed;
            TxtVersaoBeta.Text = string.Format(Idiomas.T("SobreVersaoBeta"), AppVersion.VersaoParaAtualizacao);
            TxtVersaoBeta.Visibility = Visibility.Visible;
        }

        private void AoTemaMudar(bool temaClaro)
        {
            BarraTituloNativa.AplicarTema(this, !temaClaro);
        }

        private void AplicarIdioma()
        {
            Title = Idiomas.T("TituloSobre");
            TxtVersao.Text = AppVersion.Numero;
            TxtDescricao.Text = Idiomas.T("SobreDescricao");
            TxtRotuloAutor.Text = Idiomas.T("SobreAutor");
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e) => Close();
    }
}
