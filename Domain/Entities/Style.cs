using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApi.Domain
{
  public class Style : BaseEntity
  {
    [MaxLength(32)]
    [MinLength(32)]
    public string Category_Id { get; set; }
    [ForeignKey("Category_Id")]
    public Category Category { get; set; }
  }
}