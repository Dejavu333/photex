using Microsoft.Extensions.Configuration;
using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;
using System.Net;

namespace PHOTEX._SERVICE
{
    class PhotoService : IPhotoService<Text, Photo>
    {
        //properties
        public readonly IPhotoRepository<Photo> _photoRepository;

        //constructors
        public PhotoService(IPhotoRepository<Photo> p_photoRepository)
        {
            this._photoRepository = p_photoRepository;
        }

        //methods
        public Text textFromPhoto(Photo p_photo)
        {
            //process image
            string base64ImageRepresentation = base64TFromPhoto(p_photo);

            //send request
            string key = "AIzaSyDvpDjE3LciozkYcFAtDCPYHdkDbrerCqw";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://vision.googleapis.com/v1/images:annotate?key=" + key);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string json =
                        @"{
                            'requests':
                            [{
                                'image':
                                {
                                    'content':'" + base64ImageRepresentation + @"'
                                },
                                'features':
                                [{
                                    'type':'TEXT_DETECTION',
                                    'maxResults':1        
                                }]
                            }]
                        }";

                streamWriter.Write(json);
            }

            //handle response
            string response = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            //output
            return TextFromResponse(response);
        }

        
        private string base64TFromPhoto(Photo p_photo)
        {
            // Read the contents of the image file into a byte array. A byte array is a series of bytes
            // (values between 0 and 255) that represent the data in a file. 
            // The values of a byte are between 0 and 255 because a byte is a unit of digital information that consists of 8 bits, and each bit can have one of two values: 0 or 1. This means that a byte can have 2^8, or 256, different values (0 to 255).
            byte[] imageArray = System.IO.File.ReadAllBytes(p_photo.fullpath);

            // Convert the byte array into a base64 string. To do this, the following steps are performed:
            // 1. Each byte in the byte array is represented as a pair of hexadecimal digits.
            // 2. The hexadecimal representation of the data is split into groups of 6 bits.
            // 3. A table of 64 characters is used to convert each group of 6 bits into a character.
            // 4. The characters are added to the base64 string.
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            // Return the base64 string.
            return base64ImageRepresentation;
        }

        
        private Text TextFromResponse(string p_jsonResponse)
        {
            var r = p_jsonResponse.Split('"');
            var text = r[11];
                
            return new Text(text = text.Replace("\\n", Environment.NewLine));    // Insert a newline character in the text
        }

        
        public async Task<Photo> shotPhoto()
        {
            Photo photo = null;
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult p = await MediaPicker.Default.CapturePhotoAsync();   //Call the CapturePhotoAsync method to open the camera and let the user take a p. If the user takes a p, the return value of the method will be a non-null value. 
                if (p != null)
                {
                    //save the file into local storage
                    string directory = FileSystem.CacheDirectory;
                    string photoPath = Path.Combine(directory, p.FileName);
                    using (Stream sourceStream = await p.OpenReadAsync())
                    {
                        using FileStream localFileStream = File.OpenWrite(photoPath);
                        {
                            await sourceStream.CopyToAsync(localFileStream);
                        }
                    }
                    photo = new Photo(p.FileName, directory);
                }
            }
            return photo;
        }

        
        public async Task<Photo> localPhoto()
        {
            return await _photoRepository.readOne();
        }
    }

}


