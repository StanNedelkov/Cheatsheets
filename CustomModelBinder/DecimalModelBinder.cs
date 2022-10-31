using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LeetCoteTests.CustomModelBinder
{
    /// <summary>
    /// Checks the input data if the decimal number uses "," or "." and convirts it to the format of the server regardles
    /// This will not work if the number has a second separator mark for its one-thousands.
    /// </summary>
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult= bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && 
                !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal actualValue = 0M;
                bool success = false;

                try
                {
                    string decValue = valueResult.FirstValue;
                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    success = true;
                    actualValue = Convert.ToDecimal(decValue);
                }
                catch (FormatException fe)
                {

                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }
                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
