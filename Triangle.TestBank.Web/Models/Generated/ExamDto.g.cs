using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Triangle.TestBank.Web.Models
{
    public partial class ExamDtoGen : GeneratedDto<Triangle.TestBank.Data.Models.Exam>
    {
        public ExamDtoGen() { }

        private int? _ExamId;
        private string _Name;
        private Triangle.TestBank.Data.Models.Subjects? _Subject;
        private Triangle.TestBank.Data.Models.Terms? _Term;
        private string _PdfPath;

        public int? ExamId
        {
            get => _ExamId;
            set { _ExamId = value; Changed(nameof(ExamId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public Triangle.TestBank.Data.Models.Subjects? Subject
        {
            get => _Subject;
            set { _Subject = value; Changed(nameof(Subject)); }
        }
        public Triangle.TestBank.Data.Models.Terms? Term
        {
            get => _Term;
            set { _Term = value; Changed(nameof(Term)); }
        }
        public string PdfPath
        {
            get => _PdfPath;
            set { _PdfPath = value; Changed(nameof(PdfPath)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Triangle.TestBank.Data.Models.Exam obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.ExamId = obj.ExamId;
            this.Name = obj.Name;
            this.Subject = obj.Subject;
            this.Term = obj.Term;
            this.PdfPath = obj.PdfPath;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Triangle.TestBank.Data.Models.Exam entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(ExamId))) entity.ExamId = (ExamId ?? entity.ExamId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Subject))) entity.Subject = (Subject ?? entity.Subject);
            if (ShouldMapTo(nameof(Term))) entity.Term = (Term ?? entity.Term);
            if (ShouldMapTo(nameof(PdfPath))) entity.PdfPath = PdfPath;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Triangle.TestBank.Data.Models.Exam MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Triangle.TestBank.Data.Models.Exam()
            {
                Name = Name,
                Subject = (Subject ?? default),
                Term = (Term ?? default),
                PdfPath = PdfPath,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(ExamId))) entity.ExamId = (ExamId ?? entity.ExamId);

            return entity;
        }
    }
}
