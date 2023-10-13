namespace Factory.Models
{
  public class ActiveRepairs
  {
    public int ActiveRepairsId { get; set; }
    public int EngineerId { get; set; }
    public Engineer Engineer { get; set; }
    public int MachineId { get; set; }
    public Machine Machine { get; set; }
  }
}