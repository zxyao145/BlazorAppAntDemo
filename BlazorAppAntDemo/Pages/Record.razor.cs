using AntDesign;
using BlazorAppAntDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorAppAntDemo.Pages
{
  public partial class Record
  {
    [Inject] private MessageService Message { get; set; }
    [Inject] private NotificationService Notice { get; set; }

    private string ExpandIconPosition { get; set; }
    private int i = 1;
    private List<Personell> PersonellData { get; set; } = new List<Personell>();
    private List<string> ImgUrls { get; set; } = new List<string>();
    private List<FileData> FileData { get; set; } = new List<FileData>();

    private string imageUrl;
    private int maxFileSize;
    private byte[] profilePictureByteArray;
    private bool loading;

    [Parameter] public RecordModel RecordModel { get; set; }

    protected override void OnInitialized()
    {
      this.RecordModel.Date = DateTime.Now;
      this.ExpandIconPosition = "left";
      this.maxFileSize = 400000;
    }

    private void OnDateSelected(DateTimeChangedEventArgs args)
    {
      this.RecordModel.Date = args.Date;
    }

    private void Callback(string[] keys)
    {

    }

    private async Task OnFileSelection(InputFileChangeEventArgs e)
    {
      foreach (IBrowserFile file in e.GetMultipleFiles(this.maxFileSize))
      {
        if (file.Size < this.maxFileSize)
        {
          IBrowserFile imgFile = file;
          this.profilePictureByteArray = new byte[imgFile.Size];
          await imgFile.OpenReadStream().ReadAsync(profilePictureByteArray);
          string imageType = imgFile.ContentType;
          this.imageUrl = $"data:{imageType};base64,{Convert.ToBase64String(profilePictureByteArray)}";
          this.ImgUrls.Add(imageUrl);
          this.FileData.Add(new FileData
          {
            Data = profilePictureByteArray,
            FileType = imageType,
            Size = imgFile.Size
          });
        }
        else
        {
          await Message.Error("File is too large!", 5);

          await this.Notice.Open(new NotificationConfig()
          {
            Message = "title",
            Duration = 0,
            Description = "File is too large!"
          });
        }
      }
    }
  }
}
