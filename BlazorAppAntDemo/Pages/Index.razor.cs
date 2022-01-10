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

    string editorValue { get; set; } = "I hope you see me :)";

    public Index()
    {
      this.DiaryRecordModel = new DiaryRecord();
      this.DiaryRecordModel.Date = DateTime.Now;
    }

    protected override void OnInitialized()
    {

    }

    private async Task OnCreateNewDiaryRecord()
    {
      if (true)
      {
        this.DiaryRecordModel = new DiaryRecord
        {
          Id = this.DiaryRecordModel.Id,
          Title = this.DiaryRecordModel.Title,
          Description = this.DiaryRecordModel.Description,
          Employees = this.DiaryRecordModel.Employees,
          Date = this.SelectedDate,
        };

        await InvokeAsync(this.StateHasChanged);
      }
      isDialogVisible = false;
    }

    private async Task OnEditDiaryRecord()
    {
      if (true)
      {
        this.DiaryRecordModel = new DiaryRecord
        {
          Id = this.DiaryRecordModel.Id,
          Title = this.DiaryRecordModel.Title,
          Description = "My text",
          Employees = this.DiaryRecordModel.Employees,
          Date = this.SelectedDate,
        };

        await InvokeAsync(this.StateHasChanged);
      }
      isDialogVisible = true;
    }

    private async Task Success()
    {
      await this.Message.Success("This is a success message");
    }
  }
}
