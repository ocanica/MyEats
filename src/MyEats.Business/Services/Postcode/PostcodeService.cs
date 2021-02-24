using Microsoft.Extensions.Logging;
using MyEats.Business.Helper;
using MyEats.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEats.Business.Services.Postcode
{
    public class PostcodeService : IPostcodeService
    {
        private readonly ILogger<PostcodeService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PostcodeService(ILogger<PostcodeService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public int GetPostcodeId(string postcode)
        {
            var outcode = PostcodeHelper.ExtractOutcode(postcode);
            var result = _unitOfWork.Postcodes.Find(x => x.PostcodePrefix.Contains(outcode)).FirstOrDefault().PostcodeId;

            return result;

        }

        public bool PostcodeExists(string postcode)
        {
            _logger.LogDebug($"{nameof(PostcodeService)} int {nameof(PostcodeExists)}");

            var outcode = PostcodeHelper.ExtractOutcode(postcode);
            var exists = _unitOfWork.Postcodes.Find(x => x.PostcodePrefix == outcode).Any();

            _logger.LogDebug($"{nameof(PostcodeService)} end {nameof(PostcodeExists)}");

            return exists;
        }
    }
}
