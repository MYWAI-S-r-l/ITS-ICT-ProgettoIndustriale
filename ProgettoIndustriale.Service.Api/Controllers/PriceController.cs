﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Business;
using ProgettoIndustriale.Business.Imp;
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Service.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class PriceController : ControllerBase
{
    
    private readonly IPriceManager _priceManager;
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
   
    public PriceController(IConfiguration configuration, ProgettoIndustrialeContext context)
    {
        _configuration = configuration;
        _context = context;
        _priceManager = new PriceManager(_context);
    }
    
}