using AntDesign;
using BlazorAppAntDemo.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppAntDemo.Pages
{
  public partial class Index
  {
    private Form<RecordModel> _form;

    [Inject]
    public MessageService Message { get; set; }

    private RecordModel RecordModel { get; set; }
    private bool isDialogVisible;
    private List<RecordModel> RecordList { get; set; } = new List<RecordModel>();

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

    private void OnSubmitForm()
    {
      _form.Submit();
    }

    private async Task OnCreateNewDiaryRecord()
    {
      if (true)
      {
        this.RecordModel = new RecordModel
        {
            Id = Guid.NewGuid(),
            Title = this.RecordModel.Title,
            Description = this.RecordModel.Description,
            Employees = this.RecordModel.Employees,
            Date = this.RecordModel.Date,
        };

        this.RecordList.Add(this.RecordModel);

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
          Date = this.RecordModel.Date,
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
