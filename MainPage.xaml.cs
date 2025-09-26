namespace BmiCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            string weightText = WeightEntry.Text?.Replace(',', '.');
            string heightText = HeightEntry.Text?.Replace(',', '.');

            if (!double.TryParse(weightText, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double weight) || //честно, часть кода не моя, нашел в интернете :)
        !double.TryParse(heightText, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double heightCm))
            {
                ResultLabel.Text = "Введите правильные числа.";
                ResultLabel.TextColor = Colors.Red;
                return;
            }

            if (weight <= 0 || heightCm <= 0)
            {
                ResultLabel.Text = "Вес и рост должны быть больше нуля.";
                ResultLabel.TextColor = Colors.Red;
                return;
            }

            double heightM = heightCm / 100.0;
            double bmi = weight / (heightM * heightM);

            string category;
            Color color;

            if (bmi < 18.5)
            {
                category = "Недостаточная масса";
                color = Colors.Orange;
            }
            else if (bmi < 25)
            {
                category = "Нормальная масса";
                color = Colors.Green;
            }
            else if (bmi < 30)
            {
                category = "Избыточная масса";
                color = Colors.OrangeRed;
            }
            else
            {
                category = "Ожирение";
                color = Colors.Red;
            }

            ResultLabel.Text = $"BMI = {bmi:F1} — {category}";
            ResultLabel.TextColor = color;
        }

        private string GetCategory(double bmi)
        {
            if (bmi < 18.5) return "Недостаточная масса тела";
            if (bmi < 25) return "Нормальная масса";
            if (bmi < 30) return "Избыточная масса";
            return "Ожирение";
        }

        private Color GetCategoryColor(double bmi)
        {
            if (bmi < 18.5) return Color.FromArgb("#FFA726");
            if (bmi < 25) return Color.FromArgb("#39FF14");
            if (bmi < 30) return Color.FromArgb("#FF9800");
            return Color.FromArgb("#F44336");
        }

        private string GetAdvice(double bmi)
        {
            if (bmi < 18.5) return "Рекомендуется проконсультироваться с врачом!";
            if (bmi < 25) return "Отличная новость — поддерживайте текущий образ жизни";
            if (bmi < 30) return "Рекомендуется следить за питанием";
            return "Обратитесь к врачу для оценки состояния!";
        }

    }
}
