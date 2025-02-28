using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace LiveCharts2Sample.Feature.Graph.ViewModels;

public class HorizontalLineContentModel :ObservableObject
{
    public ISeries[] Series { get; set; }
    public ICartesianAxis[] XAxes { get; set; } = [
       new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("MM.dd"))];
    public HorizontalLineContentModel()
    {
        Random r = new Random ();

        List<DateTimePoint> values = new ();
        for (int i = 0; i < 50; i++)
        {
            values.Add (new ()
            {
                DateTime = DateTime.Now.AddDays (-(50 - i)),
                Value = (double)r.Next (0, 2)
            });
        }

        Series = new ISeries[]
        {
            new StackedStepAreaSeries<DateTimePoint>
            {
                Values = values.ToArray(),
                Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 5, StrokeJoin = SKStrokeJoin.Round },
                
                Fill = null
            }
        };
    }
}
