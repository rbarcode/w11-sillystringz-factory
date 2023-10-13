using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId  { get; set; }
    [Required]
    public string Name { get; set; }
    public string Status { get; set; }
    public List<Licensure> JoinEntitiesLicensure { get; }
    public List<ActiveRepairs> JoinEntitiesActiveRepairs { get; }
    public readonly string[] availableStatuses = { "Operational", "Nonoperational"};
  }
}