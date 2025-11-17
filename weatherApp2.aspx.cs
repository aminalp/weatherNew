using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;

namespace weatherNew
{
    public partial class weatherApp2 : System.Web.UI.Page
    {

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
            string city = ddlCity.SelectedValue.ToLower();

            DateTime timeToFetch = DateTime.UtcNow.AddHours(1);
            DateTime nextFullHourUtc = new DateTime(timeToFetch.Year, timeToFetch.Month, timeToFetch.Day,
                                                     timeToFetch.Hour, 0, 0, DateTimeKind.Utc);

            string targetTimeString = nextFullHourUtc.ToString("s") + "Z";

            string url = $"https://opendata.fmi.fi/wfs?service=WFS&version=2.0.0&request=getFeature&storedquery_id=fmi::forecast::harmonie::surface::point::timevaluepair&place={city}&parameters=temperature,windspeedms,winddirection&";

            double temp = 0;
            double windMS = 0;
            double windDirection = 0;
            bool dataFound = false;

            try
            {
                WebClient client = new WebClient();
                string xmlData = client.DownloadString(url);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("wml2", "http://www.opengis.net/waterml/2.0");
                nsmgr.AddNamespace("gml", "http://www.opengis.net/gml/3.2");

                string xPathQuery = $"//wml2:MeasurementTVP[wml2:time='{targetTimeString}']";

                XmlNodeList nodes = xmlDoc.SelectNodes(xPathQuery, nsmgr);

                if (nodes.Count > 0)
                {
                    foreach (XmlNode node in nodes)
                    {
                        string value = node.SelectSingleNode("wml2:value", nsmgr).InnerText;

                        if (value.Equals("NaN", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        XmlNode timeSeries = node.SelectSingleNode("ancestor::wml2:MeasurementTimeseries", nsmgr);
                        string seriesId = timeSeries.Attributes["gml:id"].Value;

                        if (seriesId.Contains("temperature"))
                        {
                            temp = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                            dataFound = true;
                        }
                        else if (seriesId.Contains("windspeedms"))
                        {
                            windMS = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                        }
                        else if (seriesId.Contains("winddirection"))
                        {
                            windDirection = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                        }
                    }
                }

                if (!dataFound)
                {
                    lblTemp.Text = "No forecast data for the next hour.";
                    lblWindSpeed.Text = "-";
                    lblWindDir.Text = "-";
                    lblFeelsLikeCity.Text = "-";
                    lblTimestamp.Text = "Forecast time: -";
                    return;
                }

                double windKMH = windMS * 3.6;
                double vPow = Math.Pow(windKMH, 0.16);
                double feelsLike = 13.12 + (0.6215 * temp) - (11.37 * vPow) + (0.3965 * temp * vPow);

                string feelsLikeText;
                if (temp > 10 || windKMH <= 4.8)
                {
                    feelsLikeText = temp.ToString("0.0") + "°C";
                }
                else
                {
                    feelsLikeText = feelsLike.ToString("0.0") + "°C";
                }

                lblTimestamp.Text = "Forecast for: " + nextFullHourUtc.ToLocalTime().ToString("HH:mm");
                lblTemp.Text = "Temperature: " + temp.ToString("0.0") + "°C";
                lblWindSpeed.Text = $"Wind Speed: {windMS.ToString("0.0")} m/s ({windKMH.ToString("0.0")} km/h)";
                string cardinalDirection = ConvertDegreesToCardinal(windDirection);
                lblWindDir.Text = $"Wind Direction: {cardinalDirection} ({windDirection.ToString("0.0")}°)";
                lblFeelsLikeCity.Text = "Feels Like: " + feelsLikeText;

            }
            catch (WebException ex)
            {
                lblTemp.Text = "Could not connect to FMI data service.";
                lblTimestamp.Text = "Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblTimestamp.Text = "Error: " + ex.Message;
            }
        }

        private string ConvertDegreesToCardinal(double degrees)
        {
            string[] directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

            int index = (int)Math.Floor(((degrees + 22.5) % 360) / 45.0);

            return directions[index];
        }
    }
 }
    

