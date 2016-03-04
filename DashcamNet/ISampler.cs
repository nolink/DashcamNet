using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface ISampler
    {
        /**
     * 确定是否要对一个span进行trace
     *
     * @return true or false
     */
        bool next();
    }
}
