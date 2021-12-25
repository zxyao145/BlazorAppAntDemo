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
    private List<string> CategoryList { get; set; } 
    private string selectedCategoryValue;
    private List<Personell> PersonellData { get; set; }
    private List<string> ImgUrls { get; set; }
    private List<FileData> FileData { get; set; }

    private string imageUrl;
    private int maxFileSize;
    private byte[] profilePictureByteArray;
    private bool loading;

    [Parameter] public DiaryRecord DiaryRecord { get; set; }

    public Record()
    {
      this.ExpandIconPosition = "left";
      this.PersonellData = new List<Personell>();
      this.ImgUrls = new List<string>();
      this.FileData = new List<FileData>();
      this.maxFileSize = 400000;
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
      this.DiaryRecord.Date = args.Date;
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
