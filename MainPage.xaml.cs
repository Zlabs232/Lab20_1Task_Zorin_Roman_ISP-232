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
            if (!double.TryParse(WeightEntry.Text, out double weight) ||
                !double.TryParse(HeightEntry.Text, out double heightCm))
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

    }
}
