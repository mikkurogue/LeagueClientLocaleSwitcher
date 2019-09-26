using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.IO;

namespace LeagueClientLocaleSwitcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenerateComboBoxItems();

           if (ReadSetting("LeagueclientLocation") != "")
            {
                if (File.Exists(ReadSetting("LeagueclientLocation")))
                {
                    SelectedClientPath.Content = ReadSetting("LeagueclientLocation");
                }
                else
                {
                    MessageBox.Show("League Client not found in normal install location. Please set the LeagueClient.exe path here. It will be saved for future use after this. This is a one time message.", "LeagueClient.exe not found.");
                }
            } 
        }
        private void btnLaunchClient_Click(object sender, RoutedEventArgs e)
        {

            //string clientLocation = "C:\\Riot Games\\League of Legends\\LeagueClient.exe";
            System.Diagnostics.Process.Start(SelectedClientPath.Content.ToString(), $"--locale={cmbLocales.SelectedItem.ToString()}");
        }

        private void CmbLocales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblSelected.Content = cmbLocales.SelectedItem;
            btnLaunchClient.IsEnabled = true;
        }

        private void GenerateComboBoxItems()
        {
            cmbLocales.Items.Add(Locales.EnglishUS());
            cmbLocales.Items.Add(Locales.EnglishUK());
            cmbLocales.Items.Add(Locales.EnglishAUS());
            cmbLocales.Items.Add(Locales.KoreanKR());
            cmbLocales.Items.Add(Locales.PortugeseBR());
            cmbLocales.Items.Add(Locales.JapaneseJP());
            cmbLocales.Items.Add(Locales.GermanDE());
            cmbLocales.Items.Add(Locales.FrenchFR());
            cmbLocales.Items.Add(Locales.CzechCZ());
            cmbLocales.Items.Add(Locales.GreekGR());
            cmbLocales.Items.Add(Locales.HungarianHU());
            cmbLocales.Items.Add(Locales.ItalianIT());
            cmbLocales.Items.Add(Locales.PolishPL());
            cmbLocales.Items.Add(Locales.RomanianRO());
            cmbLocales.Items.Add(Locales.RussianRU());
            cmbLocales.Items.Add(Locales.SpanishES());
            cmbLocales.Items.Add(Locales.SpanishMX());
            cmbLocales.Items.Add(Locales.TurkishTR());
        }

        private void BtnSelectClientPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                SelectedClientPath.Content = ofd.FileName;
                UpdateSetting("LeagueclientLocation", ofd.FileName);
            }
        }

        private string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key];

            return result;
        }

        private void UpdateSetting(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings[key].Value = value;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
