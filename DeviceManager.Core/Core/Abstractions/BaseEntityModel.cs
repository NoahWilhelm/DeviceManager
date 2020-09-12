using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeviceManager.Core.Core.Abstractions
{
    public abstract class BaseEntityModel<T> 
    {
        [Key]
        public T Entry_Id { get; set; }
    }
}
