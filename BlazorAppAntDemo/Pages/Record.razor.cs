using AntDesign;
using BlazorAppAntDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppAntDemo.Pages
{
  public partial class Record
  {
    private string ExpandIconPosition { get; set; }
    private int i = 1;
    private List<string> CategoryList { get; set; } 
    private string selectedCategoryValue;
    private List<Personell> PersonellData { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public DateTime SelectedDate { get; set; }

    public Record()
    {
      this.ExpandIconPosition = "left";
      this.PersonellData = new List<Personell>();
    }


    protected override void OnInitialized()
    {
      this.CategoryList = new List<string> { { "A" }, { "B" }, { "C" }, { "D" }, { "E" }, };
    }

    private void AddNew()
    {
      this.PersonellData.Add(new Personell
      {
        Id = i + 1,
        Name = "John " + i,
        From = DateTime.Now,
        Category = this.selectedCategoryValue,
      });

      i++;
    }

    private void Delete(int id)
    {
      this.PersonellData = this.PersonellData.Where(d => d.Id != id).ToList();
    }

    private void OnSelectedItemChangedHandler(string value)
    {
      this.selectedCategoryValue = value;
    }

    private void OnDateSelected(DateTimeChangedEventArgs args)
    {
      this.SelectedDate = args.Date;
    }

    private void Callback(string[] keys)
    {

    }
  }
}
