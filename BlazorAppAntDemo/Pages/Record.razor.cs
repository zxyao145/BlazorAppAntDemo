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
    private List<Category> CategoryList { get; set; } = new List<Category>();
    private List<Personell> PersonellData { get; set; } = new List<Personell>();
    private List<string> ImgUrls { get; set; } = new List<string>();
    private List<FileData> FileData { get; set; } = new List<FileData>();

    private string imageUrl;
    private int maxFileSize;
    private byte[] profilePictureByteArray;
    private bool loading;

    [Parameter] public Models.RecordModel DiaryRecord { get; set; }

    protected override void OnInitialized()
    {
      this.CategoryList.Add(new Category { CategoryName = "CategoryA", CategorySymbol = "A" });
      this.CategoryList.Add(new Category { CategoryName = "CategoryB", CategorySymbol = "B" });
      this.CategoryList.Add(new Category { CategoryName = "CategoryC", CategorySymbol = "C" });
      this.CategoryList.Add(new Category { CategoryName = "CategoryD", CategorySymbol = "D" });

      this.ExpandIconPosition = "left";
      this.maxFileSize = 400000;
    }

    private void AddNew()
    {
      this.PersonellData.Add(new Personell
      {
        Id = i + 1,
        Name = "John " + i,
        From = DateTime.Today + new TimeSpan(7, 30, 0),
      });

      this.DiaryRecord.Employees = new List<Personell>(this.PersonellData);

      i++;
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
