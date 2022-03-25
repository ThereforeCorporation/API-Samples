using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Therefore.WebAPI
{
    /// <summary>
    /// the base class for credentials
    /// </summary>
    public abstract class BaseCredentials
    {
        public string UserName { get; private set; }

        public BaseCredentials(string userName)
        {
            this.UserName = userName;
        }

        public virtual void ResetCredentials()
        {
            UserName = null;
        }

        public abstract bool IsValid();

        public abstract void ResetKey();
    }
}
