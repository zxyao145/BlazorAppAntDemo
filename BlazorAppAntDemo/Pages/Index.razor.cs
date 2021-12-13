using AntDesign;
using BlazorAppAntDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppAntDemo.Pages
{
  public partial class Index
  {
    [Inject]
    public MessageService Message { get; set; }

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

    private async Task Success()
    {
      await this.Message.Success("This is a success message");
    }
  }
}
