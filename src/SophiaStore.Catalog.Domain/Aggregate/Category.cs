using System.Collections.Generic;
using SophiaStore.Core.DomainObjects;

namespace SophiaStore.Catalog.Domain.Aggregate
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public int Code { get; private set; }

        //ef relational
        public ICollection<Product> Product { get; set; }
        protected Category()
        {

        }
        public Category(string name, int code)
        {
            Name = name;
            Code = code;

            IsValid();
        }

        public void IsValid()
        {
            AssertionConcern.IsEmpty(Name, "Name Field can't be empty");
            AssertionConcern.IsEquals(Code, 0, "Value Field can't be 0 or less");
        }
    }
}
