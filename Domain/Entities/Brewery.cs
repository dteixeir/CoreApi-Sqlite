namespace dotNetApi.Domain
{
  public class Brewery : BaseEntity
  {
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Code { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public string FilePath { get; set; }
    public string Description { get; set; }
  }
}