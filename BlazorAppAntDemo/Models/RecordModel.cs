using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppAntDemo.Models
{
  public class RecordModel
  {
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public ICollection<Personell> Employees { get; set; }
  }
}
