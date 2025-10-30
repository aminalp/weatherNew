<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weatherApp2.aspx.cs" Inherits="weatherNew.weatherApp2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
  body {
    font-family: Arial, sans-serif;
    background: #e8f1f5;
    margin: 0;
    padding: 0;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  h1 {
    margin-top: 20px;
    color: #333;
  }

  .container {
    background: #fff;
    border-radius: 12px;
    padding: 20px;
    width: 320px;
    box-shadow: 0 0 10px rgba(0,0,0,0.1);
    margin-top: 20px;
  }

  select, input {
    width: 100%;
    padding: 10px;
    margin-top: 8px;
    border-radius: 6px;
    border: 1px solid #ccc;
    font-size: 15px;
  }

  .weather-box {
    margin-top: 15px;
    background: #f7fafc;
    padding: 15px;
    border-radius: 8px;
  }

  .weather-box p {
    margin: 6px 0;
    color: #333;
  }

  .custom-section {
    margin-top: 25px;
    padding-top: 10px;
    border-top: 1px solid #ddd;
  }

  .placeholder {
    height: 35px;
    background: #dfe7ea;
    border-radius: 5px;
    margin-top: 8px;
  }

  footer {
    margin-top: 20px;
    color: #777;
    font-size: 14px;
  }
</style>
</head>
<body>
    <form id="form1" runat="server" method="post">
      
            <h1 style="color:DarkMagenta;">Wind<span style="color:Red">X</span> Finnish Weather</h1>

            <div class="container">
              <label for="city">Select a City</label>
              <select id="city">
                <option>Helsinki</option>
                <option>Tampere</option>
                <option>Turku</option>
                <option>Oulu</option>
                <option>Lahti</option>
                <option>Jyväskylä</option>
                <option>Kuopio</option>
              </select>

              <div class="weather-box">
                <p><strong>Temperature:</strong> 6°C</p>
                <p><strong>Wind Speed:</strong> 15 km/h</p>
                <p><strong>Wind Direction:</strong> NE</p></br>
                <p style="color:OrangeRed;"><strong>Feels Like:</strong> 3°C</p>
              </div>

              <div class="custom-section">
                <h3>Feels like calculator</h3>
	            <p style="color:LightSlateGrey;"><i>Try your own values</i></p>
                <label>Custom Temperature (°C)</label>
                <div class="placeholder"></div>

                <label>Custom Wind Speed (km/h)</label>
                <div class="placeholder"></div>

                <label style="color:OrangeRed;">Calculated Feels Like</label>
                <div class="placeholder"></div>
              </div>
            </div>

           <footer>WindX Weather App, developed by LAB UAS Students'BIT2025</footer>
       
    </form>
</body>
</html>
