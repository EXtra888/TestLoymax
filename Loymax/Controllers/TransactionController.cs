using AutoMapper;
using Loymax.Data;
using Loymax.Dto;
using Loymax.Interfaces;
using Loymax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using TestLoymax.Models;

namespace Loymax.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ITransactionPepository _transactionRepository;

        public TransactionController(ApplicationContext context, IMapper mapper, ITransactionPepository transactionPepository)
        {
            _context = context;
            _mapper = mapper;
            _transactionRepository = transactionPepository;
        }

        [HttpPost("AddTransaction")]
        public async Task<ActionResult> AddTransaction([FromBody] TransactionDto transaction)
        {
            if (transaction == null)
            {
                return BadRequest(); // 400 Неверный запрос
            }

            var result = _mapper.Map<Transaction>(transaction);

            await _transactionRepository.CreateTransaction(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserBalance")]
        public async Task<ActionResult> GetUserBalance([FromQuery] int id)
        {
            if (id == 0)
            {
                return BadRequest(); // 400 Неверный запрос
            }

            var result = await _transactionRepository.GetBalanceUser(id);

            return Ok(result);
        }


    }
}
