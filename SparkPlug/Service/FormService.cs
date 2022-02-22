using Model;
using Model.Dto;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FormService : IFormService
    {
        private readonly IMongoClient _mongoClient;
        public FormService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<Tuple<bool, string>> AddForm(FormToAddDto model, string client)
        {
            var formData = _mongoClient.GetDatabase(client); //Fetch from Database
            var collection = formData.GetCollection<Form>("message");
            if(collection == null) await formData.CreateCollectionAsync("message"); //check if (collection is null
            //Mapping 
            var form = new Form
            {
                Id=Guid.NewGuid().ToString(),
                Name = model.customerName,
                Email = model.customerEmail,
                Feedback = model.customerMessage,
                FormName = model._formName,
                FormDomainName = model._formDomainName
            };
            try
            {
                await collection.InsertOneAsync(form);
                return new Tuple<bool, string>(true, "Success");
            }
            catch
            {
                return new Tuple<bool, string>(false, "Unsuccessful");
            }
        }
    }
}
