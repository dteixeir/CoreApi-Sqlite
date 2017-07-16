using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApi.Domain
{
  public class Beer : BaseEntity
  {
    public int AlcoholByVolume { get; set; }
    public int InternationalBitternessUnits { get; set; }
    public int StandardReferenceMethod { get; set; }
    public int UniversalProductCode { get; set; }
    public string Filepath { get; set; }
    public string Description { get; set; }
    [MaxLength(32)]
    [MinLength(32)]
    public string Brewery_Id { get; set; }
    [ForeignKey("Brewery_Id")]
    public Brewery Brewery { get; set; }

    [MaxLength(32)]
    [MinLength(32)]
    public string Category_Id { get; set; }
    [ForeignKey("Category_Id")]
    public Category Category { get; set; }

    [MaxLength(32)]
    [MinLength(32)]
    public string Style_Id { get; set; }
    [ForeignKey("Style_Id")]
    public Style Style { get; set; }
  }
}