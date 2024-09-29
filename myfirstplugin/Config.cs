using Exiled.API.Interfaces;
using System.ComponentModel;

namespace myfirstplugin
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Show Debug Logs.")]
        public bool Debug { get; set; } = false;

    }
}
