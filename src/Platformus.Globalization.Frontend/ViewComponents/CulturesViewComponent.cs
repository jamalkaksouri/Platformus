﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Platformus.Barebone.Frontend.ViewComponents;
using Platformus.Globalization.Frontend.ViewModels.Shared;

namespace Platformus.Globalization.Frontend.ViewComponents
{
  public class CulturesViewComponent : ViewComponentBase
  {
    public CulturesViewComponent(IStorage storage)
      : base(storage)
    {
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      return this.HttpContext.RequestServices.GetService<ICache>().GetCulturesViewComponentResultWithDefaultValue(
        () => this.GetViewComponentResult()
      );
    }

    private IViewComponentResult GetViewComponentResult()
    {
      return this.View(new CulturesViewModelFactory(this).Create());
    }
  }
}