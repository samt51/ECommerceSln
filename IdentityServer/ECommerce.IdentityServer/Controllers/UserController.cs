using System.Linq;
using System.Threading.Tasks;
using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Shared.AllShared.Interfaces.Mapper;
using ECommerce.Shared.Dtos;

namespace ECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(SignupDto signupDto)
        {

            var mapData = _mapper.Map<ApplicationUser, SignupDto>(signupDto);

            var result = await _userManager.CreateAsync(mapData, signupDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContentResult>.Fail(result.Errors.Select(y => y.Description).ToList()));
            }

            return Ok(ResponseDto<NoContentResult>.Success());
        }
    }
}
