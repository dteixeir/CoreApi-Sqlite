using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApi.Domain
{
  public class BaseEntity
  {
    [MaxLength(32)]
    [MinLength(32)]
    public string Id { get; set; }
    public string Name { get; set; }
  }
}