using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DeviceManager.API.Swagger.OperationFilters
{
    public class SwaggerJsonFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.OperationId == "Post_JsonFile")
            {

                operation.Parameters.Clear();

                var uploadFileMediaType = new OpenApiMediaType()
                {
                    Schema = new OpenApiSchema()
                    {
                        Type = "object",
                        Properties =
                        {
                        ["uploadedJsonFile"] = new OpenApiSchema()
                        {
                            Description = "Upload JSON File",
                            Type = "file",
                            Format = "binary"

                        }
                    },
                        Required = new HashSet<string>()
                        {
                            "uploadedJsonFile"
                        }
                    }
                };
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content =
                    { 
                        ["multipart/form-data"] = uploadFileMediaType
                    }
                };


            }

        }
    }
}
