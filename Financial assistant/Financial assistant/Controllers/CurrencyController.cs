using AutoMapper;
using Financial_assistant.DTO.Classes;
using Financial_assistant.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public readonly IMapper _mapper;

        public CurrencyController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Get all сurrencies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CurrencyDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAsync()
        {
            var currencies = await _currencyService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CurrencyDto>>(currencies));
        }
    }
}
