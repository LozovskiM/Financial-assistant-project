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
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService, IMapper mapper) : base(mapper)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        ///     Get all transactions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransactionDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAsync()
        {
            var transactions = await _transactionService.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<TransactionDto>>(transactions));
        }

        /// <summary>
        ///     Get single transaction.
        /// </summary>
        /// <param name="id">The transaction identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(TransactionDetailsDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null) return NotFound();

            return Ok(Mapper.Map<TransactionDetailsDto>(transaction));
        }

        /// <summary>
        ///     Create transaction.
        /// </summary>
        /// <param name="TransactionCreateDto">The transaction need to be created.</param>
        /// <returns>The created transaction.</returns>
        /// <response code="200">The transaction created.</response>
        /// <response code="400">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(TransactionDetailsDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] TransactionCreateDto transactionCreateDto)
        {
            var modelToCreate = Mapper.Map<Transaction>(transactionCreateDto);
            var createdModel = await _transactionService.CreateAsync(modelToCreate);
            var createdDto = Mapper.Map<TransactionDetailsDto>(createdModel);
            return Ok(createdDto);
        }

        /// <summary>
        ///     Update transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <param name="transactionUpdateDto">The transaction model.</param>
        /// <returns>The created transaction.</returns>
        /// <response code="200">The transaction created.</response>
        /// <response code="400">Internal server error.</response>
        /// <response code="404">The transaction was not found.</response>
        [HttpPut]
        [Route("{transactionId:int}")]
        [ProducesResponseType(typeof(TransactionDetailsDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int transactionId, [FromBody] TransactionUpdateDto transactionUpdateDto)
        {
            var transaction = await _transactionService.GetByIdAsync(transactionId);
            if (transaction == null) return NotFound();

            transactionUpdateDto.Id = transaction.Id;

            var transactionModel = Mapper.Map<Transaction>(transactionUpdateDto);
            var result = await _transactionService.UpdateAsync(transactionModel);
            return Ok(Mapper.Map<TransactionDetailsDto>(result));
        }

        /// <summary>
        ///     Delete transaction.
        /// </summary>
        /// <param name="transactionId">The transaction identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The transaction was successfully deleted.</response>
        /// <response code="404">The transaction was not found.</response>
        [HttpDelete]
        [Route("{transactionId:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int transactionId)
        {
            var transaction = await _transactionService.GetByIdAsync(transactionId);
            if (transaction == null) return NotFound();

            var result = await _transactionService.DeleteAsync(transactionId);
            return Ok(result);
        }
    }
}
