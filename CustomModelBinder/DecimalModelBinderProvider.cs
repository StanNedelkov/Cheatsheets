using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoteTests.CustomModelBinder
{
    /// <summary>
    /// set the custom model binder to be called only when the data type is decimal or nullable decimal
    /// to work add to startup: 
    /// builder.Services.AddControllerWithViews()
    /// .AddMvcOptions(options => 
    /// {
    /// options.ModelBinderProviders.Insert(0, new DecimalModelBinder)
    /// });
    ///
    /// </summary>
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(Decimal) || 
                context.Metadata.ModelType == typeof(Decimal?)) 
               return new DecimalModelBinder();

            return null;
        }
    }
}
