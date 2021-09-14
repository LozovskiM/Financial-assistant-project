using AutoMapper;
using Financial_assistant.Attributes;
using Financial_assistant.Controllers.BaseControllers;
using Financial_assistant.DTO.Сlasses;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services;
using Financial_assistant.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Financial_assistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        private readonly IConvertationService _convertationService;
        private readonly IUserService _userService;
        private readonly ApiKey _apiKey;
        HttpClient _client = new HttpClient();
        private const string CURRENCY_API_URL = "http://api.exchangeratesapi.io/v1/latest?access_key=";

        public CurrencyController(IUserService userService, JWTService jwtService, ICurrencyService currencyService, IConvertationService convertationService, IMapper mapper, IOptions<ApiKey> apiKey) : base(mapper)
        {
            _currencyService = currencyService;
            _convertationService = convertationService;
            _userService = userService;
            _apiKey = apiKey.Value;
        }

        [HttpGet]
        [Route("updateCurrenciesAdmin")]
        public async Task UpdateCurrenciesAdmin()
        {
            var key = _apiKey.Currency;
            var responseString = await _client.GetStringAsync(CURRENCY_API_URL + key);
            var currencies = JsonConvert.DeserializeObject<CurrencyApi>(responseString);

            if (currencies != null)
            {
                _convertationService.DeleteConvertationData();
                _currencyService.DeleteCurrencyData();

                foreach (var code in currencies.Rates.Keys)
                {
                    var currency = new Currency
                    {
                        Name = code,
                        Code = code
                    };
                    var createdModel = await _currencyService.CreateAsync(currency);
                }
            }

            foreach (var firstCurrency in currencies.Rates)
            {
                foreach (var secondCurrency in currencies.Rates)
                {
                    var firstId = _currencyService.GetByCode(firstCurrency.Key).Id;
                    var secondId = _currencyService.GetByCode(secondCurrency.Key).Id;
                    var createdModel = await _convertationService.CreateAsync(new Convertation { 
                        CurrencyFromId = firstId,
                        CurrencyToId = secondId,
                        ExchangeRate = secondCurrency.Value / firstCurrency.Value
                    });
                }
            }
        }

        /// <summary>
        ///     Get all сurrencies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Auth]
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

        /// <summary>
        ///     Create currency.
        /// </summary>
        /// <param name="CurrencyCreateDto">The currency need to be created.</param>
        /// <returns>The created currency.</returns>
        /// <response code="200">The currency created.</response>
        /// <response code="400">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(CurrencyDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] CurrencyCreateDto currencyCreateDto)
        {
            var modelToCreate = Mapper.Map<Currency>(currencyCreateDto);
            var createdModel = await _currencyService.CreateAsync(modelToCreate);
            var createdDto = Mapper.Map<CurrencyDto>(createdModel);

            return Ok(createdDto);
        }

        /// <summary>
        ///     Update currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="CurrencyCreateDto">The currency model.</param>
        /// <returns>The created currency.</returns>
        /// <response code="200">The currency created.</response>
        /// <response code="400">Internal server error.</response>
        /// <response code="404">The currency was not found.</response>
        [HttpPut]
        [Route("{currencyId:int}")]
        [ProducesResponseType(typeof(CurrencyDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int currencyId, [FromBody] CurrencyDto currencyUpdateDto)
        {
            var currency = await _currencyService.GetByIdAsync(currencyId);
            if (currency == null) return NotFound();

            currencyUpdateDto.Id = currency.Id;

            var currencyModel = Mapper.Map<Currency>(currencyUpdateDto);
            var result = await _currencyService.UpdateAsync(currencyModel);
            return Ok(Mapper.Map<CurrencyDto>(result));
        }

        /// <summary>
        ///     Delete currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The currency was successfully deleted.</response>
        /// <response code="404">The currency was not found.</response>
        [HttpDelete]
        [Route("{currencyId:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int currencyId)
        {
            var currency = await _currencyService.GetByIdAsync(currencyId);
            if (currency == null) return NotFound();

            var result = await _currencyService.DeleteAsync(currencyId);
            return Ok(result);
        }
    }
}
