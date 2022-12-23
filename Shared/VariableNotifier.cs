using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class VariableNotifier
    {
        public string ApiKey { get; set; }

        public VariableNotifier()
        {

        }

        public async Task UpdateApiValue(string value)
        {
            ApiKey = value;

            await Notify?.Invoke();

        }

        public event Func<Task> Notify;
    }
}
