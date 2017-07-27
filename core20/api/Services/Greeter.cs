using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        private readonly AppSettings _appSettings;

        public Greeter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GetGreeting()
        {
            return _appSettings.Greeting;
        }
    }
}
