using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApi.Domain
{
  public class UUID
  {
    public String Value
    {
      get { return Value; }
      set
      {
        if (Value.Length != 32)
        {
          throw new ArgumentException("Invalid UUID");
        }

        Value = value;
      }
    }
  }
}