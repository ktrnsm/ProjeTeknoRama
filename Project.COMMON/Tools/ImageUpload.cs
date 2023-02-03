using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUpload
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if(file!=null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.');

                string extension= fileArray[fileArray.Length -].ToLower();

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
