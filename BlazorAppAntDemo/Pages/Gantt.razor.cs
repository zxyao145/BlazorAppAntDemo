using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BlazorAppAntDemo.Pages
{
  public partial class Gantt
  {
    [Inject] public HttpClient HttpClient { get; set; }
    [Inject] protected IJSRuntime js { get; set; }

    private string jsonDataPath;

    protected override async Task OnInitializedAsync()
    {
      await base.OnInitializedAsync();
      //_menuData = await HttpClient.GetFromJsonAsync<MenuDataItem[]>("data/menu.json");

      this.jsonDataPath = "en";
      //await js.InvokeAsync<object>("start", this.jsonDataPath);
    }

    protected override async void OnAfterRender(bool firstRender)
    {
      this.jsonDataPath = "./data/data.json";
      await js.InvokeAsync<object>("start", "en", this.jsonDataPath);
    }
  }
}
