using System;

namespace weatherNew
{
    public partial class weatherApp2 : System.Web.UI.Page
    {
        Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Nothing to do here. State is maintained automatically by ViewState
        }

        protected void btnGetWeather_Click(object sender, EventArgs e)
        {
            // Get selected city
            string city = ddlCity.SelectedValue;

            // Generate random weather data
            int temp = rnd.Next(-10, 26); // -10°C to 25°C
            int windSpeed = rnd.Next(5, 41); // 5-40 km/h
            string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
            string windDir = directions[rnd.Next(directions.Length)];

            int feelsLike = temp - (int)(windSpeed * 0.1); // simple formula

            // Display in labels
            lblTemp.Text = temp.ToString();
            lblWindSpeed.Text = windSpeed.ToString();
            lblWindDir.Text = windDir;
            lblFeelsLike.Text = feelsLike.ToString();
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTemp.Text) || string.IsNullOrWhiteSpace(txtWind.Text))
                {
                    lblResult.Text = "Enter both values!";
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                double temp = Convert.ToDouble(txtTemp.Text);
                double wind = Convert.ToDouble(txtWind.Text);

                // Simple feels like formula
                double feelsLike = temp - 0.7 * (wind / 10);
                lblResult.Text = feelsLike.ToString("0.0") + " °C";
                lblResult.ForeColor = System.Drawing.Color.OrangeRed;
            }
            catch
            {
                lblResult.Text = "Invalid input!";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
