using System;

namespace Data
{
    public class FormDbSsettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string ConnectionString
        {
            get { return $"mongodb://{Host}:{Port}"; }
        }
    }
}
