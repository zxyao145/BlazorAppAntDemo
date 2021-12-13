using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppAntDemo.Models
{
  public class SaveFile
  {
    public List<FileData> Files { get; set; }
  }
  public class FileData
  {
    public byte[] Data { get; set; }
    public string FileType { get; set; }
    public long Size { get; set; }
  }
}
