using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    //The code path is a static class named "ImageUpload" in the "Project.COMMON.Tools" namespace. This class has a single public static method named "UploadImage" which is used to upload an image file to a server path. The method takes two parameters, a "serverPath" string that specifies the path to store the image file on the server, and an "HttpPostedFileBase" object named "file" that represents the image file to be uploaded. The method first checks if the file is not null, and then generates a unique name for the image file by creating a new Guid and concatenating it with the file extension. The method then checks if the extension of the file is one of the allowed formats (jpg, png, jpeg, gif) and if a file with the same name already exists in the server path. If the extension is not allowed, the method returns "2", if a file with the same name already exists, the method returns "1", and if the file is null, the method returns "3". If all conditions are met, the method saves the image file to the specified server path and returns the full path to the image file.

    public static class ImageUpload // Copied from another project
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if(file!=null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.');

                string extension= fileArray[fileArray.Length -1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if(extension=="jpg"||extension=="png"|| extension=="jpeg"||extension=="gif")
                {
                    if(File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1";
                    }

                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }

                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "3";
            }
        }
    }
}
