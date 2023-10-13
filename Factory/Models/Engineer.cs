using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public List<Licensure> JoinEntitiesLicensure { get; }
    public List<ActiveRepairs> JoinEntitiesActiveRepairs { get; }
  }
}