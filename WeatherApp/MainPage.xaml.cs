﻿namespace WeatherApp;

public partial class MainPage : ContentPage, IDisposable
{
    private int count;


    public MainPage()
    {
        InitializeComponent();
    }


    /// <inheritdoc />
    void IDisposable.Dispose()
    {
        Application.Current.Quit();
    }


    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}