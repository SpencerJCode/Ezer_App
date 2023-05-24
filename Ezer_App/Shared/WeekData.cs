#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Ezer_App.Shared
{

  public class WeekData
  {
    [Key]
    public int WeekId { get; set; }
    public string WeekLink { get; set; }
    public string BabyImage { get; set; }
    public string KeyTakeawaysList { get; set; }
    public string KeyTakeawaysBottom { get; set; }
    public string BabyActivity { get; set; }
    public string BabySize { get; set; }
  }
}
