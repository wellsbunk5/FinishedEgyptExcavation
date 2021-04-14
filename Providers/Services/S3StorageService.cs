using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Providers.Services
{
    public class S3StorageService : IStorageService
    {
        //AWS credentials
        private readonly AmazonS3Client s3Client;
        private const string BUCKET_NAME = "arn:aws:s3:us-east-1:358320312956:accesspoint/readwriteinternet";
        private const string FOLDER_NAME = "resources";
        private const double DURATION = 24;

        public S3StorageService()
        {
            var credentials = new BasicAWSCredentials("AKIAVG3MOCJ6LVKEVPSF", "YPNwWLrp5ZYBvin9kcVUxrPj7z+N9fFpvCfUmeRt");
            s3Client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
        }

        public async Task<string> AddItem(IFormFile file)
        {
            //implementation for S3 bucket
            string fileName = file.FileName;
            string objectKey = $"{FOLDER_NAME}/{fileName}";

            using (Stream fileToUpload = file.OpenReadStream())
            {
                var putObjectRequest = new PutObjectRequest();
                putObjectRequest.BucketName = BUCKET_NAME;
                putObjectRequest.Key = objectKey;
                putObjectRequest.InputStream = fileToUpload;
                putObjectRequest.ContentType = file.ContentType;

                var response = await s3Client.PutObjectAsync(putObjectRequest);

                return GeneratePreSignedURL(objectKey);
            }
        }
        private string GeneratePreSignedURL(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BUCKET_NAME,
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };

            string url = s3Client.GetPreSignedURL(request);
            return url;
        }

    }
}
