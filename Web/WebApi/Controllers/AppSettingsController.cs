using Application.Repositories;
using Application.Requests;
using Domain.Master;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {

        private readonly IAppSettingsRepository _appSettingsRepository;

        public AppSettingsController(IAppSettingsRepository repository)
        {
            _appSettingsRepository = repository;
        }

        /// <summary>
        /// Returns existing app settings
        /// </summary>
        /// <returns>List of app settings</returns>
        /// <response code="200">List of existing app settings</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AppSetting>), statusCode: StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_appSettingsRepository.GetAppSettings());
        }

        /// <summary>
        /// Returns existing app setting
        /// </summary>
        /// <param name="appSettingId">Guid of existing app setting</param>
        /// <returns>App setting</returns>
        /// <response code="200">Existing app setting</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(AppSetting), statusCode: StatusCodes.Status200OK)]
        [HttpGet("{appSettingId}")]
        public IActionResult GetById([FromRoute] string appSettingId)
        {
            return new OkObjectResult(_appSettingsRepository.GetAppSettingById(Guid.Parse(appSettingId)));
        }

        /// <summary>
        /// Creates new app setting
        /// </summary>
        /// <param name="request" required="true">New app setting request</param>
        /// <returns>Guid of newly created app setting</returns>
        /// <response code="201">   Guid of newly created app setting</response>
        /// <response code="400">Unaccessible request</response>
        [Consumes(typeof(CreateAppSettingRequest),"application/json", IsOptional = false)]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Guid), statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create([FromBody(EmptyBodyBehavior = Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior.Disallow)] CreateAppSettingRequest request)
        {
            var appSettingId = Guid.NewGuid();
            try
            {
                appSettingId = _appSettingsRepository.CreateAppSetting(new AppSetting
                {
                    ReferenceKey = request.ReferenceKey,
                    Value = request.Value,
                    Description = request.Description,
                    Type = request.Type
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Created("", appSettingId);
        }

        /// <summary>
        /// Updates existing app setting
        /// </summary>
        /// <param name="request">Edit app settings request</param>
        /// <returns></returns>
        /// <response code="204">App setting updated successfully</response>
        /// <response code="400">Unaccessible request</response>
        [Consumes(typeof(UpdateAppSettingRequest), "application/json", IsOptional = false)]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateAppSettingRequest request)
        {
            try
            {
                var appSettingId = _appSettingsRepository.UpdateAppSetting(new AppSetting
                {
                    Id = request.Id,
                    ReferenceKey = request.ReferenceKey,
                    Value = request.Value,
                    Description = request.Description,
                    Type = request.Type
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes existing app setting
        /// </summary>
        /// <param name="appSettingId">Guid of existing app setting</param>
        /// <returns></returns>
        /// <response code="204">App setting deleted successfully</response>
        /// <response code="400">Unaccessible request</response>
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [HttpDelete("{appSettingId}")]
        public IActionResult Delete([FromRoute] string appSettingId)
        {
            try
            {
                _appSettingsRepository.DeleteAppSetting(Guid.Parse(appSettingId));
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return NoContent();
        }
    }
}
