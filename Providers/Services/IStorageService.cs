using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Providers.Services
{
    //interface for S3StorageService to inherit from
    public interface IStorageService
    {
        Task<string> AddItem(IFormFile file);
    }
}