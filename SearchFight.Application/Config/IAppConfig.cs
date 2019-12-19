using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Application.Config
{
    public interface IAppConfig
    {
        string ServiceUrl();
        string GetOcpApimSubscriptionKey();
    }
}
