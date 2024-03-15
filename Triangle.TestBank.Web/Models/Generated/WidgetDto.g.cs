using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Triangle.TestBank.Web.Models
{
    public partial class WidgetDtoGen : GeneratedDto<Triangle.TestBank.Data.Models.Widget>
    {
        public WidgetDtoGen() { }

        private int? _WidgetId;
        private string _Name;
        private Triangle.TestBank.Data.Models.WidgetCategory? _Category;
        private System.DateTimeOffset? _InventedOn;

        public int? WidgetId
        {
            get => _WidgetId;
            set { _WidgetId = value; Changed(nameof(WidgetId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public Triangle.TestBank.Data.Models.WidgetCategory? Category
        {
            get => _Category;
            set { _Category = value; Changed(nameof(Category)); }
        }
        public System.DateTimeOffset? InventedOn
        {
            get => _InventedOn;
            set { _InventedOn = value; Changed(nameof(InventedOn)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(Triangle.TestBank.Data.Models.Widget obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.WidgetId = obj.WidgetId;
            this.Name = obj.Name;
            this.Category = obj.Category;
            this.InventedOn = obj.InventedOn;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(Triangle.TestBank.Data.Models.Widget entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(WidgetId))) entity.WidgetId = (WidgetId ?? entity.WidgetId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Category))) entity.Category = (Category ?? entity.Category);
            if (ShouldMapTo(nameof(InventedOn))) entity.InventedOn = InventedOn;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override Triangle.TestBank.Data.Models.Widget MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new Triangle.TestBank.Data.Models.Widget()
            {
                Name = Name,
                Category = (Category ?? default),
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(WidgetId))) entity.WidgetId = (WidgetId ?? entity.WidgetId);
            if (ShouldMapTo(nameof(InventedOn))) entity.InventedOn = InventedOn;

            return entity;
        }
    }
}
