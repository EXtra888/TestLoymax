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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserDto createUser)
        {
            if(createUser == null)
            {
                return BadRequest(); // 400 Неверный запрос
            }

            var user = _mapper.Map<User>(createUser);

            await _userRepository.CreateAsync(user);

            return Ok(createUser);
        }

        [HttpGet]
        [Route("GetBalance")]
        public async Task<ActionResult> GetBalanceUser(int id)
        {
           if(id == 0)
            {
                return BadRequest();
            }

            var result = await _userRepository.GetAmountMoney(id);
            return Ok(result);
        }
    }
}
