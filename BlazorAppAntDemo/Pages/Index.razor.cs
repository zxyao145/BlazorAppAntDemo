using AntDesign;
using BlazorAppAntDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppAntDemo.Pages
{
  public partial class Index
  {
    [Inject]
    public MessageService Message { get; set; }

    private RecordModel RecordModel { get; set; }
    private bool isDialogVisible;
    private DateTime SelectedDate { get; set; }

    protected override void OnInitialized()
    {
      this.RecordModel = new RecordModel();
      this.RecordModel.Date = DateTime.Now;
    }

    private void OnDialogOpen()
    {
      this.RecordModel = new RecordModel();
      this.isDialogVisible = true;
    }

    private async Task OnCreateNewDiaryRecord()
    {
      if (true)
      {
        this.RecordModel = new RecordModel
        {
          Id = this.RecordModel.Id,
          Title = this.RecordModel.Title,
          Description = this.RecordModel.Description,
          Employees = this.RecordModel.Employees,
          Date = this.SelectedDate,
        };

        await InvokeAsync(this.StateHasChanged);
      }
      isDialogVisible = false;
    }

    private async Task OnEditRecord()
    {
      if (true)
      {
        this.RecordModel = new RecordModel
        {
          Id = this.RecordModel.Id,
          Title = "My title",
          Description = "<p>My <strong>text</strong></p>",
          Employees = this.RecordModel.Employees,
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
