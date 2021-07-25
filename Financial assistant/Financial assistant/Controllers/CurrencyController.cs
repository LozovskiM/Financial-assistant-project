using AutoMapper;
using Financial_assistant.Controllers.BaseControllers;
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
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService, IMapper mapper) : base(mapper)
        {
            _currencyService = currencyService;
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
            return Ok(Mapper.Map<IEnumerable<CurrencyDto>>(currencies));
        }

        /// <summary>
        ///     Get single currency.
        /// </summary>
        /// <param name="id">The currency identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(CurrencyDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var currency = await _currencyService.GetByIdAsync(id);
            if (currency == null) return NotFound();

            return Ok(Mapper.Map<CurrencyDto>(currency));
        }
    }
}
