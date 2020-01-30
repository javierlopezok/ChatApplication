using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatApplication.Services;

namespace ChatApplication
{

    public class TestableBot : IBotService
    {
      
        public string getStock(String message)
        {
            IBotService bot = new BotService();
            return bot.getStock(message);
        }

    }

}