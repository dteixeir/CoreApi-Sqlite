using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApi.Domain
{
  public class Category : BaseEntity
  {
    public string Description { get; set; }
  }
}