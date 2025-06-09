using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _10_Thread_Affinity
{
    public class CustomControl : DispatcherObject
    {
        private int _id;
        public int Id
        {
            get
            {
                this.VerifyAccess();
                return _id;
            }
            set
            {
                this.VerifyAccess();
                _id = value;
            }
        }
    }
}
