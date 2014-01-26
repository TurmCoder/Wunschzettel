using System;
using FluentNHibernate.Automapping;
using Wunschzettel.Core;

namespace Wunschzettel.mapping
{
    public class AutomappingConfiguration:DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(BaseEntity));
        }
    }
}