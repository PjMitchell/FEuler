using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEuler.Domain
{
    public interface IEuler
    {
        int GetId();
        void Run();
        void Summary();
    }
}
