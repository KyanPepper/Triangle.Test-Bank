
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Triangle.TestBank.Web.Models;

namespace Triangle.TestBank.Web.Api
{
    [Route("api/ExamServices")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ExamServicesController : Controller
    {
        protected ClassViewModel GeneratedForClassViewModel { get; }
        protected Triangle.TestBank.Data.Services.ExamServices Service { get; }
        protected CrudContext Context { get; }

        public ExamServicesController(CrudContext context, Triangle.TestBank.Data.Services.ExamServices service)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Triangle.TestBank.Data.Services.ExamServices>();
            Service = service;
            Context = context;
        }

        /// <summary>
        /// Method: HealthCheck
        /// </summary>
        [HttpPost("HealthCheck")]
        [Authorize]
        public virtual ItemResult<string> HealthCheck()
        {
            var _methodResult = Service.HealthCheck();
            var _result = new ItemResult<string>();
            _result.Object = _methodResult;
            return _result;
        }

        /// <summary>
        /// Method: PostExam
        /// </summary>
        [HttpPost("PostExam")]
        [Authorize]
        public virtual async Task<ItemResult<ExamDtoGen>> PostExam(
            [FromServices] Azure.Storage.Blobs.BlobContainerClient blobStorageClient,
            [FromForm(Name = "name")] string name,
            [FromForm(Name = "subject")] Triangle.TestBank.Data.Models.Subjects subject,
            [FromForm(Name = "term")] Triangle.TestBank.Data.Models.Terms term,
            Microsoft.AspNetCore.Http.IFormFile file)
        {
            var _params = new
            {
                name = name,
                subject = subject,
                term = term,
                file = file == null ? null : new IntelliTect.Coalesce.Models.File { Name = file.FileName, ContentType = file.ContentType, Length = file.Length, Content = file.OpenReadStream() }
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("PostExam"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<ExamDtoGen>(_validationResult);
            }

            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = await Service.PostExam(
                _params.name,
                _params.subject,
                _params.term,
                _params.file,
                blobStorageClient
            );
            var _result = new ItemResult<ExamDtoGen>();
            _result.Object = Mapper.MapToDto<Triangle.TestBank.Data.Models.Exam, ExamDtoGen>(_methodResult, _mappingContext, includeTree);
            return _result;
        }

        /// <summary>
        /// Method: CheckPassCode
        /// </summary>
        [HttpPost("CheckPassCode")]
        [Authorize]
        public virtual async Task<ItemResult<bool>> CheckPassCode(
            [FromServices] string pass,
            [FromForm(Name = "userInput")] string userInput)
        {
            var _params = new
            {
                userInput = userInput
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("CheckPassCode"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<bool>(_validationResult);
            }

            var _methodResult = await Service.CheckPassCode(
                _params.userInput,
                pass
            );
            var _result = new ItemResult<bool>();
            _result.Object = _methodResult;
            return _result;
        }
    }
}
