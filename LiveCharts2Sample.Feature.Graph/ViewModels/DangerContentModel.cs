using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace LiveCharts2Sample.Feature.Graph.ViewModels;

public class DangerContentModel : ObservableObject
{
    public ISeries[] Series { get; set; }

    public RectangularSection[] Sections { get; set; } = [
        new RectangularSection
        {
            Label = "Max Value",
            LabelSize = 15,
            LabelPaint = new SolidColorPaint(SKColors.Blue)
            {
                SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
            },
            Yj = 40,
            Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(30))
        },
        new RectangularSection
        {
            Label = "Min Value",
            LabelSize = 15,
            LabelPaint = new SolidColorPaint(SKColors.Red)
            {
                SKTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
            },
            Yi = 20,            
            Fill = new SolidColorPaint(SKColors.Red.WithAlpha(10))
        },
    ];
    public ICartesianAxis[] XAxes { get; set; } = [
       new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("MM.dd"))
   ];
    public DangerContentModel()
    {
        Random r = new Random ();
        List<DateTimePoint> values = new();
        for (int i = 0; i < 50; i++)
        {
            values.Add (new ()
            {
                DateTime = DateTime.Now.AddDays (-(50 - i)),
                Value = (double)r.Next (0, 50)
            });
        }

        Series = [new LineSeries<DateTimePoint >
        {
            Values = values.ToArray(),
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 1
        }];
    }
}
