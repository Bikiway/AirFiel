using System.IO;

namespace AirFiel_Mariana_Oliveira.Data.API
{
    public class Flags
    {
        private string? _png;

        private string? _svg;

        private string? _localImage;

        private CitiesAPI _apiCities;

        public string Png
        {
            get
            {
                if (_png == null || _png.Length == 0)
                    return "pack://application:,,,/Imagens/no_flag.png";

                return _png;
            }
            set
            {
                _png = value;
            }
        }
        public string Svg
        {
            get
            {
                if (_svg == null || _svg.Length == 0)
                    return "pack://application:,,,/Imagens/no-flag.svg";

                return _svg;
            }
            set
            {
                _svg = value;
            }
        }
        public string LocalImage { get; set; } = "pack://application:,,,/Imagens/no_flag.png";
        public string ShowFlags
        {
            get
            {
                string flagPath = Directory.GetCurrentDirectory() + @"/Flags/" + $"{_apiCities.CCA3}.png";

                if (File.Exists(flagPath))
                    return LocalImage;

                if (Png == null || Png.Length == 0)
                    return "pack://application:,,,/Imagens/no_flag.png";

                return Png;
            }
        }

        public Flags(CitiesAPI bandeira)
        {
            _apiCities = bandeira;
        }
    }
}
