using Microsoft.AspNetCore.Components;

namespace Scorecard.Components.Score;
public partial class Score
{
    [Parameter]
    public int Par { get; set; } = default;
    private List<(int Value, string Label)> StrokeValues { get; set; } = new List<(int Value, string Label)>();

    private static Dictionary<int, List<(int, string)>> ResultLabels = new() {
        {3, new () {
            ( 0, "" ),
            ( 1, "1" ),
            ( 2, "2" ),
            ( 3, "3" ),
            ( 4, "4" ),
            ( 5, "5" ),
            ( 6, "6" ),
            ( 7, "7" ),
            ( 8, "8" )
            }
        },
        {4, new () {
            ( 0, "" ),
            ( 1, "1" ),
            ( 2, "2" ),
            ( 3, "3" ),
            ( 4, "4" ),
            ( 5, "5" ),
            ( 6, "6" ),
            ( 7, "7" ),
            ( 8, "8" ),
            ( 9, "9" )
            }
        },
        {5, new () {
            ( 0, "" ),
            ( 1, "1" ),
            ( 2, "2" ),
            ( 3, "3" ),
            ( 4, "4" ),
            ( 5, "5" ),
            ( 6, "6" ),
            ( 7, "7" ),
            ( 8, "8" ),
            ( 9, "9" ),
            ( 10, "10" )
            }
        },
        {6, new () {
            ( 0, "" ),
            ( 1, "1" ),
            ( 2, "2" ),
            ( 3, "3" ),
            ( 4, "4" ),
            ( 5, "5" ),
            ( 6, "6" ),
            ( 7, "7" ),
            ( 8, "8" ),
            ( 9, "9" ),
            ( 10, "10" ),
            ( 11, "11" )
            }
        }
    };

    protected override Task OnInitializedAsync()
    {
        StrokeValues = ResultLabels[Par];
        return base.OnInitializedAsync();
    }

}
