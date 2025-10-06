using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<string> UploadImage(string imageBase64);

        Task<string> DeletePhotoAsync(string publicId);
    }
}