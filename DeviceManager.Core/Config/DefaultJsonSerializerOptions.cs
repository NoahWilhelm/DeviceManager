using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DeviceManager.Core.Config
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions GetIgnoreCase()
        {
            return new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true
        };
    }
}
}
