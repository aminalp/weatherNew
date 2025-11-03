<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weatherApp2.aspx.cs" Inherits="weatherNew.weatherApp2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WindX Finnish Weather</title>
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
        h1 { margin-top: 20px; color: #333; }
        .container {
            background: #fff;
            border-radius: 12px;
            padding: 20px;
            width: 320px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            margin-top: 20px;
        }
        select, input { width: 100%; padding: 10px; margin-top: 8px; border-radius: 6px; border: 1px solid #ccc; font-size: 15px; }
        .weather-box { margin-top: 15px; background: #f7fafc; padding: 15px; border-radius: 8px; }
        .weather-box p { margin: 6px 0; color: #333; }
        .custom-section { margin-top: 25px; padding-top: 10px; border-top: 1px solid #ddd; }
        footer { margin-top: 20px; color: #777; font-size: 14px; }
        .btn { background: #4CAF50; color: white; border: none; border-radius: 6px; padding: 8px; width: 100%; cursor: pointer; margin-top: 10px; }
        .btn:hover { background: #45a049; }
        .error { color: red; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="color:DarkMagenta;">Wind<span style="color:Red">X</span> Finnish Weather</h1>

        <div class="container">
            <label for="city">Select a City</label>
            <asp:DropDownList ID="ddlCity" runat="server">
                <asp:ListItem>Helsinki</asp:ListItem>
                <asp:ListItem>Tampere</asp:ListItem>
                <asp:ListItem>Turku</asp:ListItem>
                <asp:ListItem>Oulu</asp:ListItem>
                <asp:ListItem>Lahti</asp:ListItem>
                <asp:ListItem>Jyväskylä</asp:ListItem>
                <asp:ListItem>Kuopiooo</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnGetWeather" runat="server" CssClass="btn" Text="Get Weather" OnClick="btnGetWeather_Click" />

            <div class="weather-box">
                <p><strong>Temperature:</strong> <asp:Label ID="lblTemp" runat="server" Text="-"></asp:Label>°C</p>
                <p><strong>Wind Speed:</strong> <asp:Label ID="lblWindSpeed" runat="server" Text="-"></asp:Label> km/h</p>
                <p><strong>Wind Direction:</strong> <asp:Label ID="lblWindDir" runat="server" Text="-"></asp:Label></p>
                <br />
                <p style="color:OrangeRed;"><strong>Feels Like:</strong> <asp:Label ID="lblFeelsLike" runat="server" Text="-"></asp:Label>°C</p>
            </div>

            <div class="custom-section">
                <h3>Feels Like Calculator</h3>
                <p style="color:LightSlateGrey;"><i>Try your own values</i></p>

                <label>Custom Temperature (°C)</label>
                <asp:TextBox ID="txtTemp" runat="server"></asp:TextBox>

                <label>Custom Wind Speed (km/h)</label>
                <asp:TextBox ID="txtWind" runat="server"></asp:TextBox>

                <asp:Button ID="btnCalc" runat="server" CssClass="btn" Text="Calculate Feels Like" OnClick="btnCalc_Click" />

                <label style="color:OrangeRed;">Calculated Feels Like:</label>
                <asp:Label ID="lblResult" runat="server" Text="-"></asp:Label>
            </div>
        </div>

        <footer>WindX Weather App, developed by LAB UAS Students' BIT2025</footer>
    </form>
</body>
</html>
