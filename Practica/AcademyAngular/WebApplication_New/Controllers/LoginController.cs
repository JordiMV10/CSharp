﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academy.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_New.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/Login
        [HttpPost]
        public Task<bool> Post([FromBody] LoginDto login)
        {
            return Task.Run(() =>
            {

                if (!string.IsNullOrEmpty(login.Email) &&
                    !string.IsNullOrEmpty(login.Password))
                    return true;

                else
                    return false;
            });
        }
    }
}