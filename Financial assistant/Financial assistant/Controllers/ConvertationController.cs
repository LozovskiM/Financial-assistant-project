using AutoMapper;
using Financial_assistant.Controllers.BaseControllers;
using Financial_assistant.DTO.Сlasses;
using Financial_assistant.Models.DbModels;
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
    public class ConvertationController : BaseController
    {
        private readonly IConvertationService _convertationService;
        private readonly ICurrencyService _currencyService;

        public ConvertationController(IConvertationService convertationService, ICurrencyService currencyService, IMapper mapper) : base(mapper)
        {
            _convertationService = convertationService;
            _currencyService = currencyService;
        }

        /// <summary>
        ///     Get all convertations.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConvertationDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAsync()
        {
            var convertations = await _convertationService.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<ConvertationDto>>(convertations));
        }

        /// <summary>
        ///     Get single convertation.
        /// </summary>
        /// <param name="id">The convertation identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ConvertationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var convertation = await _convertationService.GetByIdAsync(id);
            if (convertation == null) return NotFound();

            return Ok(Mapper.Map<ConvertationDto>(convertation));
        }

        /// <summary>
        ///     Create convertation.
        /// </summary>
        /// <param name="ConvertationCreateDto">The convertation need to be created.</param>
        /// <returns>The created convertation.</returns>
        /// <response code="200">The convertation created.</response>
        /// <response code="400">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ConvertationDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] ConvertationCreateDto convertationCreateDto)
        {
            var modelToCreate = Mapper.Map<Convertation>(convertationCreateDto);
            var createdModel = await _convertationService.CreateAsync(modelToCreate);
            var createdDto = Mapper.Map<ConvertationDto>(createdModel);
            createdDto.CurrencyFrom = Mapper.Map<CurrencyDto>(await _currencyService.GetByIdAsync(createdModel.CurrencyFromId));
            createdDto.CurrencyTo = Mapper.Map<CurrencyDto>(await _currencyService.GetByIdAsync(createdModel.CurrencyToId));
            return Ok(createdDto);
        }

        /// <summary>
        ///     Update convertation.
        /// </summary>
        /// <param name="currencyId">The convertation identifier.</param>
        /// <param name="exchangeRate">The new exchange rate.</param>
        /// <returns>The created convertation.</returns>
        /// <response code="200">The convertation created.</response>
        /// <response code="400">Internal server error.</response>
        /// <response code="404">The convertation was not found.</response>
        [HttpPut]
        [Route("{convertationId:int}")]
        [ProducesResponseType(typeof(ConvertationDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int convertationId, [FromBody] double exchangeRate)
        {
            var convertation = await _convertationService.GetByIdAsync(convertationId);
            if (convertation == null) return NotFound();

            convertation.ExchangeRate = exchangeRate;

            var result = await _convertationService.UpdateAsync(convertation);
            return Ok(Mapper.Map<ConvertationDto>(result));
        }

        /// <summary>
        ///     Delete convertation.
        /// </summary>
        /// <param name="convertationId">The convertation identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The convertation was successfully deleted.</response>
        /// <response code="404">The convertation was not found.</response>
        [HttpDelete]
        [Route("{convertationId:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int convertationId)
        {
            var convertation = await _convertationService.GetByIdAsync(convertationId);
            if (convertation == null) return NotFound();

            var result = await _convertationService.DeleteAsync(convertationId);
            return Ok(result);
        }
    }
}
