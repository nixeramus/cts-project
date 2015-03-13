using System;
using System.Web;

namespace TD.Common.Web.Mvc
{
    public class SessionRepository<T>
    {
        protected readonly string Name = "Obj_" + Guid.NewGuid();

        public T Value
        {
            get
            {
                return (T)HttpContext.Current.Session[Name];
            }
            set
            {
                HttpContext.Current.Session[Name] = value;
            }
        }

        public void Clear()
        {
            HttpContext.Current.Session[Name] = null;
        }

        public bool HasValue
        {
            get { return HttpContext.Current.Session[Name] != null; }
        }
    }
}
