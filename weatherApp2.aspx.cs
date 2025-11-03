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
                
                double feelsLike = temp - (wind / 5);
                lblFeelsLike.Text = feelsLike.ToString("0.0") + "°C";
            }
            else
            {
                lblFeelsLike.Text = "Invalid input!";
            }
        }
    
        protected void btnShowWeather_Click(object sender, EventArgs e)
        {
            string city = ddlCity.SelectedValue;

            
            int temp = 0;
            int wind = 0;
            string direction = "";
            int feelsLike = 0;

            switch (city)
            {
                case "Helsinki":
                    temp = 6; wind = 14; direction = "NW"; feelsLike = 3;
                    break;
                case "Tampere":
                    temp = 4; wind = 10; direction = "NE"; feelsLike = 2;
                    break;
                case "Turku":
                    temp = 7; wind = 12; direction = "W"; feelsLike = 5;
                    break;
                case "Oulu":
                    temp = 2; wind = 18; direction = "N"; feelsLike = -1;
                    break;
                case "Lahti":
                    temp = 5; wind = 11; direction = "SE"; feelsLike = 3;
                    break;
                case "Jyväskylä":
                    temp = 3; wind = 9; direction = "E"; feelsLike = 1;
                    break;
                case "Kuopio":
                    temp = 1; wind = 15; direction = "SW"; feelsLike = -2;
                    break;
            }

            lblTemp.Text = "Temperature: " + temp + "°C";
            lblWindSpeed.Text = "Wind Speed: " + wind + " km/h";
            lblWindDir.Text = "Wind Direction: " + direction;
            lblFeelsLikeCity.Text = "Feels Like: " + feelsLike + "°C";
        }

    }
}

