//add this code to your ASP.NET Core app in wwwroot/js create jquery.override-validator.js
//we try to override number-method
//after adding this code you need to add a script to views/shared/_validationscriptpartial.cshtml:
//<script src="~/js/jquery.override-validator.js"></script>
//if using range attribute you need to overrite it instead, best to delete it if you use this.

jQuery(function ($) {
    $.validator.addMethod('number', function (value, element) {
        return this.optional(element) || /^(?:-?\d+)(?:(\.|,)\d+)?$/.test(value);
    })
})