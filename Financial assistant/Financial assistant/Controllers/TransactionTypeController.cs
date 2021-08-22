using AutoMapper;
using Financial_assistant.Controllers.BaseControllers;
using Financial_assistant.DTO.Сlasses;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : BaseController
    {
        private readonly ITransactionTypeService _transactionTypeService;
        public TransactionTypeController(ITransactionTypeService transactionTypeService, IMapper mapper) : base(mapper)
        {
            _transactionTypeService = transactionTypeService;
        }

        /// <summary>
        ///     Get all transaction types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionTypeDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAsync()
        {
            var transactionTypes = await _transactionTypeService.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<TransactionTypeDto>>(transactionTypes));
        }

        /// <summary>
        ///     Get single transaction type.
        /// </summary>
        /// <param name="id">The transaction type identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(TransactionTypeDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var transactionType = await _transactionTypeService.GetByIdAsync(id);
            if (transactionType == null) return NotFound();

            return Ok(Mapper.Map<TransactionTypeDto>(transactionType));
        }

        /// <summary>
        ///     Create transaction type.
        /// </summary>
        /// <param name="TransactionTypeCreateDto">The transaction type need to be created.</param>
        /// <returns>The created transaction type.</returns>
        /// <response code="200">The transaction type created.</response>
        /// <response code="400">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(TransactionTypeDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] TransactionTypeCreateDto transactionTypeCreateDto)
        {
            var modelToCreate = Mapper.Map<TransactionType>(transactionTypeCreateDto);
            var createdModel = await _transactionTypeService.CreateAsync(modelToCreate);
            var createdDto = Mapper.Map<TransactionTypeDto>(createdModel);
            return Ok(createdDto);
        }

        /// <summary>
        ///     Update transaction.
        /// </summary>
        /// <param name="transactionTypeId">The transaction type identifier.</param>
        /// <param name="transactionTypeDto">The transaction type model.</param>
        /// <returns>The created transaction type.</returns>
        /// <response code="200">The transaction type created.</response>
        /// <response code="400">Internal server error.</response>
        /// <response code="404">The transaction type was not found.</response>
        [HttpPut]
        [Route("{transactionTypeId:int}")]
        [ProducesResponseType(typeof(TransactionTypeDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int transactionTypeId, [FromBody] TransactionTypeDto transactionTypeUpdateDto)
        {
            var transactionType = await _transactionTypeService.GetByIdAsync(transactionTypeId);
            if (transactionType == null) return NotFound();

            transactionTypeUpdateDto.Id = transactionType.Id;

            var transactionTypeModel = Mapper.Map<TransactionType>(transactionTypeUpdateDto);
            var result = await _transactionTypeService.UpdateAsync(transactionTypeModel);
            return Ok(Mapper.Map<TransactionTypeDto>(result));
        }

        /// <summary>
        ///     Delete transaction type.
        /// </summary>
        /// <param name="transactionTypeId">The transaction type identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The transaction type was successfully deleted.</response>
        /// <response code="404">The transaction type was not found.</response>
        [HttpDelete]
        [Route("{transactionTypeId:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int transactionTypeId)
        {
            var transactionType = await _transactionTypeService.GetByIdAsync(transactionTypeId);
            if (transactionType == null) return NotFound();

            var result = await _transactionTypeService.DeleteAsync(transactionTypeId);
            return Ok(result);
        }
    }
}
