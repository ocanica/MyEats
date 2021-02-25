using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Services.Postcode
{
    public interface IPostcodeService
    {
        bool PostcodeExists(string postcode);

        int GetPostcodeId(string postcode);

        public string GetTown(string postcode);
    }
}
