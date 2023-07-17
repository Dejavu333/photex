using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.PlatformConfiguration;
using PHOTEX.MODEL.DOMAIN;

namespace PHOTEX.MODEL.REPOSITORY
{
    class PhotoRepository: IPhotoRepository<Photo>
    {
        public async Task<Photo> readOne()
        {
            FileResult photo = await MediaPicker.PickPhotoAsync();
            string path = Path.GetDirectoryName(photo.FullPath);

            return new Photo(photo.FileName, path);
        }
    }
}
