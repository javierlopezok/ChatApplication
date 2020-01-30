using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Services
{
    public interface IBotService
    {
        string getStock(String message);
    }
}
