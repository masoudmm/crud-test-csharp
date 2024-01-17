﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;

namespace CustomerCrud.Client;

public class FluentValidationValidator : ComponentBase
{
    //[CascadingParameter] EditContext CurrentEditContext { get; set; }
    [CascadingParameter] MudForm Form { get; set; }

    protected override void OnInitialized()
    {
        //if (CurrentEditContext == null)
        //{
        //    throw new InvalidOperationException($"{nameof(FluentValidationValidator)} requires a cascading " +
        //        $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(FluentValidationValidator)} " +
        //        $"inside an {nameof(EditForm)}.");
        //}

        //CurrentEditContext.AddFluentValidation();
    }
}

