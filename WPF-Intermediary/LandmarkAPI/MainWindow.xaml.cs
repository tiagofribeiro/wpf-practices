using LandmarkAPI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace LandmarkAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Arquivos de imagem|*.png;*.jpg;*.jpeg;|Todos (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
            };
            if (dialog.ShowDialog() == true)
            {
                string fileUri = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileUri));

                MakePredictionAsync(fileUri);
            }
        }

        private async void MakePredictionAsync(string filePath)
        {
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/4c608a66-bd06-4a0f-825a-bab8ecfbd7b2/classify/iterations/FirstIteration/image";
            string prediction_key = "707e996c7bfc492bb39c75a9e46eec85";
            string content_type = "application/octet-stream";

            var image = System.IO.File.ReadAllBytes(path: filePath);

            using HttpClient client = new();
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", prediction_key);
                using ByteArrayContent content = new ByteArrayContent(image);
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(content_type);
                    var response = await client.PostAsync(url, content);

                    string responseString = await response.Content.ReadAsStringAsync();

                    List<Prediction> predictions = JsonConvert.DeserializeObject<CustomVision>(responseString).Predictions;
                    predictionListView.ItemsSource = predictions;
                }
            }
        }
    }
}
