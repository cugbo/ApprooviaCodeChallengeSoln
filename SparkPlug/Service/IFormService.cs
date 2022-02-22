using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IFormService
    {
        Task<Tuple<bool, string>> AddForm(FormToAddDto model, string client);
    }
}
