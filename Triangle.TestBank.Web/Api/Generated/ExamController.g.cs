
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
    [Route("api/Exam")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ExamController
        : BaseApiController<Triangle.TestBank.Data.Models.Exam, ExamDtoGen, Triangle.TestBank.Data.AppDbContext>
    {
        public ExamController(CrudContext<Triangle.TestBank.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Triangle.TestBank.Data.Models.Exam>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ExamDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Triangle.TestBank.Data.Models.Exam> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ExamDtoGen>> List(
            ListParameters parameters,
            IDataSource<Triangle.TestBank.Data.Models.Exam> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Triangle.TestBank.Data.Models.Exam> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ExamDtoGen>> Save(
            [FromForm] ExamDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Triangle.TestBank.Data.Models.Exam> dataSource,
            IBehaviors<Triangle.TestBank.Data.Models.Exam> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<ExamDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ExamDtoGen>> Delete(
            int id,
            IBehaviors<Triangle.TestBank.Data.Models.Exam> behaviors,
            IDataSource<Triangle.TestBank.Data.Models.Exam> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
