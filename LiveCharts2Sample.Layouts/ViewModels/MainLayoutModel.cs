using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts2Sample.Feature.Graph.ViewModels;

namespace LiveCharts2Sample.Layouts.ViewModels;

public partial class MainLayoutModel : ObservableObject
{
    [ObservableProperty] ObservableObject featureContent;

    public MainLayoutModel()
    {
        FeatureContent = new DangerContentModel ();
    }

    [RelayCommand]
    private void DangerZoneGraph()
    {
        FeatureContent = new DangerContentModel ();
    }

    [RelayCommand]
    private void HorizontalLineGraph()
    {
        FeatureContent = new HorizontalLineContentModel ();
    }
}
