using BlazorAppAntDemo.Models;

namespace BlazorAppAntDemo.Pages
{
  public partial class Index
  {
    private DiaryRecord DiaryRecordModel { get; set; }
    private bool isDialogVisible;
    private DateTime SelectedDate { get; set; }

    public Index()
    {
      this.DiaryRecordModel = new DiaryRecord();
      this.SelectedDate = DateTime.Now;
    }

    protected override void OnInitialized()
    {

    }

    private async Task OnCreateNewDiaryRecord()
    {
      if (true)
      {
        await OnInitializedAsync();
      }
      isDialogVisible = false;
    }
  }
}
