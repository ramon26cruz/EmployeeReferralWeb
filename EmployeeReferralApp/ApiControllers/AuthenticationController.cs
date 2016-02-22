using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeReferralApp.Infrastructure.Services;
using EmployeeReferralApp.Models;
using Microsoft.AspNet.Identity;

namespace EmployeeReferralApp.ApiControllers
{
    [RoutePrefix("api/authenticate")]
    public class AuthenticationController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ITokenGenerator _tokenGenerator;

        public AuthenticationController(UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        [AllowAnonymous]
        [Route("")]
        public IHttpActionResult Post(AuthenticateInputModel model)
        {
            if (model == null) return BadRequest("The request cannot be null");
            if (!ModelState.IsValid) return BadRequest("Invalid Request");
            var user = _userManager.Find(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var jwtToken = _tokenGenerator.GenerateFor(user.UserName);
            // get current project
            // look up will be based on the current project
            return Ok(new AuthenticationOutputModel
            {
                Id = user.Id,
                Name = user.UserName,
                JWTToken = jwtToken,
            });
        }
    }

    public class AuthenticateInputModel 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    
}

