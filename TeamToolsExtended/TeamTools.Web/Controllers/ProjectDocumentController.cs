using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TeamTools.Logic.Services.Contracts;

namespace TeamTools.Web.Controllers
{
    public class ProjectDocumentController : ApiController
    {
        private readonly IFileService fileService;

        public ProjectDocumentController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpGet]
        [Route("api/Documents/{id}")]
        public HttpResponseMessage DownloadFile(int id)
        {
            var projectDocument = this.fileService.DownloadFile(id);

            //// Build the file name.
            //var fileDownloadName = projectDocument.FileName;

            //// Build the file contents.
            //var fileContents = projectDocument.FileContent;

            //// Set the headers to indicate we are returning a file.
            //var downloadContent = new ByteArrayContent(fileContents);
            //downloadContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //downloadContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            //{
            //    FileName = fileDownloadName
            //};

            //// Respond with the file.
            //return new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = downloadContent
            //};
            HttpResponseMessage result = null;
            // sendo file to client
            byte[] bytes = projectDocument.FileContent;
            
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(bytes);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = projectDocument.FileName;
            
            return result;
        }
    }
}