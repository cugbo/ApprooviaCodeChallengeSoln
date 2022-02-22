using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Feedback { get; set; }
        public string FormName { get; set; } = "sparkPlugFeedback";
        public string FormDomainName { get; set; } = "localhost";
    }
}
