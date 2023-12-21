using Application.Binders;
using Application.DTOs.Authentication;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        [Route("Login")]
        [HttpPost]
        [SwaggerOperation(Summary = "Iniciar sesion")]
        public async Task<IActionResult> Login([FromBody] AuthenticationLoginRequest authenticationLogin)
        {
            return Ok(await AuthenticationService.SignInUserAsync(authenticationLogin));
        }

        [Route("Login/Google")]
        [HttpPost]
        [SwaggerOperation(Summary = "Iniciar sesion con google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] AuthenticationLoginGoogleRequest authenticationLoginGoogleRequest)
        {
            return Ok(await AuthenticationService.SignInWithGoogleAsync(authenticationLoginGoogleRequest));
        }

        [Route("Register")]
        [HttpPost]
        [SwaggerOperation(Summary = "Registro de nuevo usuario")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
            UserRegistrationResponse response = await AuthenticationService.SignUpUserAsync(userRegistrationRequest);
            if (response.Success)
                return NoContent();
            else
                return BadRequest(new { message = string.Join('\n', response.Errors) });
        }

        [Route("Recovery/Password")]    
        [HttpPost]
        [SwaggerOperation(Summary = "Recuperar contraseña")]
        public async Task<IActionResult> RecoveryPassword([FromBody] RecoveryPasswordRequest recoveryPasswordRequest)
        {
            if ((await AuthenticationService.RecoveryPasswordAsync(recoveryPasswordRequest)).Success)
                return NoContent();
            else
                return BadRequest();
        }

        [Route("Recovery/Validate")]
        [HttpPost]
        [SwaggerOperation(Summary = "Validar codigo otp para recuperar contraseña")]
        public async Task<IActionResult> RecoveryPassword([FromBody] ValidateOtpRecoveryPasswordRequest validateOtpRecoveryPasswordRequest)
        {
            bool response = await AuthenticationService.ValidateOtpRecoveryPasswordAsync(validateOtpRecoveryPasswordRequest);
            if (response)
                return NoContent();
            else
                return BadRequest(new { Message = "Code not valid" });
        }

        [Route("Recovery/Confirm")]
        [HttpPost]
        [SwaggerOperation(Summary = "Confirmación de codigo OTP para recuperar contraseña")]
        public async Task<IActionResult> RecoveryPassword([FromBody] RecoveryPasswordConfirmRequest recoveryPasswordConfirmRequest)
        {
            IdentityResult response = await AuthenticationService.RecoveryPasswordConfirmedAsync(recoveryPasswordConfirmRequest);
            if (response.Succeeded)
                return NoContent();
            else
                return BadRequest(new { message = string.Join('\n', response.Errors.Select(x => x.Description)) });
        }

        [Route("Activate/Send")]
        [HttpPost]
        [SwaggerOperation(Summary = "Reenviar correo de confirmacion de activación")]
        public async Task<IActionResult> ReSendConfirmEmail([FromBody] ReSendEmailConfirmationRequest reSendEmailConfirmationRequest)
        {
            if ((await AuthenticationService.ReSendEmailConfirmationAsync(reSendEmailConfirmationRequest)).Success)
                return NoContent();
            else
                return BadRequest();
        }


        [Route("Activate/Confirm")]
        [HttpPost]
        [SwaggerOperation(Summary = "Confirmar otp activación")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailConfirmationRequest confirmEmailConfirmationRequest)
        {
            IdentityResult response = await AuthenticationService.ConfirmEmailConfirmationAsync(confirmEmailConfirmationRequest);
            if (response.Succeeded)
                return NoContent();
            else
                return BadRequest(new { message = string.Join('\n', response.Errors.Select(x => x.Description)) });
        }

        [Route("Logout")]
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Inabilitar token de seguridad")]
        public async Task<IActionResult> Logout([FromBody] AccessTokenAuthorizationHeader accessTokenAuthorizationHeader)
        {
            IdentityResult response = await AuthenticationService.LogoutAsync(
                new LogoutRequest() { 
                    Token = accessTokenAuthorizationHeader.TokenValue 
            });
            if (response.Succeeded)
                return NoContent();
            else
                return BadRequest(new { message = string.Join('\n', response.Errors.Select(x => x.Description)) });
        }
    }
}