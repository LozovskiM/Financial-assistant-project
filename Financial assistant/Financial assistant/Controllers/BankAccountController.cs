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
    public class BankAccountController : BaseController
    {
        private readonly IBankAccountService _bankAccountService;
        public BankAccountController(IBankAccountService bankAccountService, IMapper mapper) : base(mapper)
        {
            _bankAccountService = bankAccountService;
        }

        /// <summary>
        ///     Get all bank accounts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankAccountDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAsync()
        {
            var bankAccounts = await _bankAccountService.GetAllAsync();
            return Ok(Mapper.Map<IEnumerable<BankAccountDto>>(bankAccounts));
        }

        /// <summary>
        ///     Get single bank account.
        /// </summary>
        /// <param name="id">The bank account identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(BankAccountDetailsDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var bankAccount = await _bankAccountService.GetByIdAsync(id);
            if (bankAccount == null) return NotFound();

            return Ok(Mapper.Map<BankAccountDetailsDto>(bankAccount));
        }

        /// <summary>
        ///     Create bank account.
        /// </summary>
        /// <param name="BankAccountCreateDto">The bank account need to be created.</param>
        /// <returns>The created bank account.</returns>
        /// <response code="200">The bank account created.</response>
        /// <response code="400">Internal server error.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BankAccountDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] BankAccountCreateDto bankAccountCreateDto)
        {
            var modelToCreate = Mapper.Map<BankAccount>(bankAccountCreateDto);
            var createdModel = await _bankAccountService.CreateAsync(modelToCreate);
            var createdDto = Mapper.Map<BankAccountDto>(createdModel);
            return Ok(createdDto);
        }

        /// <summary>
        ///     Update bank account.
        /// </summary>
        /// <param name="bankAccountId">The bank account identifier.</param>
        /// <param name="CurrencyCreateDto">The bank account model.</param>
        /// <returns>The created bank account.</returns>
        /// <response code="200">The bank account created.</response>
        /// <response code="400">Internal server error.</response>
        /// <response code="404">The bank account was not found.</response>
        [HttpPut]
        [Route("{bankAccountId:int}")]
        [ProducesResponseType(typeof(BankAccountDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int bankAccountId, [FromBody] BankAccountDto bankAccountUpdateDto)
        {
            var bankAccount = await _bankAccountService.GetByIdAsync(bankAccountId);
            if (bankAccount == null) return NotFound();

            bankAccountUpdateDto.Id = bankAccount.Id;

            var bankAccountModel = Mapper.Map<BankAccount>(bankAccountUpdateDto);
            var result = await _bankAccountService.UpdateAsync(bankAccountModel);
            return Ok(Mapper.Map<BankAccountDto>(result));
        }

        /// <summary>
        ///     Delete bank account.
        /// </summary>
        /// <param name="bankAccountId">The bank account identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The bank account was successfully deleted.</response>
        /// <response code="404">The bank account was not found.</response>
        [HttpDelete]
        [Route("{bankAccountId:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int bankAccountId)
        {
            var bankAccount = await _bankAccountService.GetByIdAsync(bankAccountId);
            if (bankAccount == null) return NotFound();

            var result = await _bankAccountService.DeleteAsync(bankAccountId);
            return Ok(result);
        }
    }
}
