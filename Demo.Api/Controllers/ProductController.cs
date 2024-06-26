﻿using System.Text.Json;
using Demo.Api.Services;
using Demo.Application.Common.Dto.Product;
using Demo.Application.Common.Interfaces;
using Demo.Application.Products.Commands;
using Demo.Application.Products.Queries;
using Demo.Domain.Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

public class ProductController(IDemoDbContext dbContext, IEnumerable<ITestProduct> testProducts) : ApiBaseController
{
    [HttpGet]
    public void TestProductDetails()
    {
        foreach (var testProduct in testProducts)
        {
            if (testProduct.GetType() == typeof(TestProductTwo))
            {
                var result = testProduct.GetDetails("test");
            }
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query) => Ok(await Mediator.Send(query));

    [HttpPost("create")]
    public async Task<IActionResult> Create(ProductCreateCommand command) => Ok(await Mediator.Send(command));    
    
    [HttpPost("test-create")]
    public async Task<IActionResult> TestCreate(ProductTestCreateDto dto)
    {
        var command = dto.Json.Deserialize<ProductCreateCommand>(SerializerExtensions.SettingsWebOptions);
        
        return Ok(await Mediator.Send(command!));
    }
}