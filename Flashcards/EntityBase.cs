using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards
{
    public abstract class EntityBase
    {
        public bool IsValid
        {
            get { return Validate(); }
        }
        protected abstract bool Validate();
    }
}
