using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Core.Contexts.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }

        #region Funcoes
        public bool Equals(Guid id)
            => Id == id;

        public override int GetHashCode()
            => Id.GetHashCode();
        #endregion
    }
}
