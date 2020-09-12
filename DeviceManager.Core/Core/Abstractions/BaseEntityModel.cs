using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DeviceManager.Core.Core.Abstractions
{
    public abstract class BaseEntityModel { }
    public abstract class BaseEntityModel<T> : BaseEntityModel 
    {
        [Key]
        public T Entry_Id { get; set; }

        public override bool Equals(object obj)
        {

            var objectType = obj.GetType();

            if (!typeof(BaseEntityModel).IsAssignableFrom(objectType)) return false;

            var ownProperties = this.GetType().GetProperties();
            var objProperties = objectType.GetProperties();
            
            bool allPropertiesEqual = true;

            foreach (var prop in ownProperties)
            {
                
                var ownValue = prop.GetValue(this);
                var objProperty = objProperties.FirstOrDefault(x => x.Name == prop.Name);

                if (objProperty == null) allPropertiesEqual = false;

                var objValue = objProperty.GetValue(obj);
                var propsEqual = (ownValue != null) ? ownValue.Equals(objValue) : (ownValue == null && objValue == null ? true : false);

                if (!propsEqual) allPropertiesEqual = false;

            }

            return allPropertiesEqual;
        }

    }
}
