using System;

namespace weatherNew
{
    public partial class weatherApp2 : System.Web.UI.Page
    {
        Random rnd = new Random();

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double temp = 0;
            double wind = 0;

            bool isTempValid = double.TryParse(txtTemp.Text, out temp);
            bool isWindValid = double.TryParse(txtWind.Text, out wind);

            if (isTempValid && isWindValid)
            {
                // Simple formula: FeelsLike = Temp - (Wind / 5)
                double feelsLike = temp - (wind / 5);
                lblFeelsLike.Text = feelsLike.ToString("0.0") + "°C";
            }
            else
            {
                lblFeelsLike.Text = "Invalid input!";
            }
        }
    }
}

