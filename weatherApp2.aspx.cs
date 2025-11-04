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

            try
            {
                temp = Convert.ToDouble(txtTemp.Text);
                wind = Convert.ToDouble(txtWind.Text);

                double vPow = Math.Pow(wind, 0.16);
                double feelsLike = 13.12 + (0.6215 * temp) - (11.37 * vPow) + (0.3965 * temp * vPow);

                if (temp > 10 || wind <= 4.8)
                {
                    lblFeelsLike.Text = "Feels like " + temp.ToString("0.0");
                }
                else
                {
                    lblFeelsLike.Text = feelsLike.ToString("0.0") + "°C";
                }
            }
            catch (FormatException)
            {
                lblFeelsLike.Text = "Invalid input! Please enter numbers only.";
            }
            catch (Exception ex)
            {
                lblFeelsLike.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void btnShowWeather_Click(object sender, EventArgs e)
        {
            string city = ddlCity.SelectedValue;

            double temp = 0;
            double wind = 0;
            string direction = "";

            switch (city)
            {
                case "Helsinki":
                    temp = 6; wind = 14; direction = "NW";
                    break;
                case "Tampere":
                    temp = 4; wind = 10; direction = "NE";
                    break;
                case "Turku":
                    temp = 7; wind = 12; direction = "W";
                    break;
                case "Oulu":
                    temp = 2; wind = 18; direction = "N";
                    break;
                case "Lahti":
                    temp = 5; wind = 11; direction = "SE";
                    break;
                case "Jyväskylä":
                    temp = 3; wind = 9; direction = "E";
                    break;
                case "Kuopio":
                    temp = 1; wind = 15; direction = "SW";
                    break;
            }

            double vPow = Math.Pow(wind, 0.16);
            double feelsLike = 13.12 + (0.6215 * temp) - (11.37 * vPow) + (0.3965 * temp * vPow);

            string feelsLikeText;
            if (temp > 10 || wind <= 4.8)
            {
                feelsLikeText = temp.ToString("0.0") + "°C";
            }
            else
            {
                feelsLikeText = feelsLike.ToString("0.0") + "°C";
            }

            lblTemp.Text = "Temperature: " + temp + "°C";
            lblWindSpeed.Text = "Wind Speed: " + wind + " km/h";
            lblWindDir.Text = "Wind Direction: " + direction;
            lblFeelsLikeCity.Text = "Feels Like: " + feelsLikeText;
        }

    }
}

