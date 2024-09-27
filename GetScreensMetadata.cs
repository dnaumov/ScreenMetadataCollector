
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Acumatica.Default_20_200_001.Model;
using Acumatica.RESTClient.Client;
using Acumatica.ScreenInfo_1.Model;

using static Acumatica.RESTClient.AuthApi.AuthApiExtensions;
using static Acumatica.RESTClient.ContractBasedApi.ApiClientExtensions;
using static Acumatica.RESTClient.FileApi.ApiClientExtensions;

namespace AcumaticaRestApiExample
{
    public class ScreensMetadataGetter
	{
		public static void GetScreensMetadata(string siteURL, string username, string password, string tenant = null, string branch = null, string locale = null)
		{
            var client = new ApiClient(siteURL,
				requestInterceptor: RequestLogger.LogRequest, 
                responseInterceptor: RequestLogger.LogResponse
                );

            try
            {
                client.Login(username, password, tenant, branch, locale);

               //read file TopLevelEntities.csv from the folder with the current executable, split it by lines
               StreamReader reader = new StreamReader("TopLevelEntities.csv");
                string[] entities = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                reader.Close();

                //get metadata for each screen
                foreach (var entity in entities.Distinct())
                {
                    try
                    {
                        var screenInfo = client.Put(new ScreenInfo() { ScreenID = entity }, expand: "Fields");
                        Console.WriteLine($"Screen {entity} has {screenInfo.Fields.Count} fields.");
                        //append it to a csv file with screenID and fields from the screenInfo
                        StreamWriter writer = new StreamWriter("ScreensMetadata.csv", true);
                        foreach (var field in screenInfo.Fields)
                        {
                            writer.WriteLine($"{entity},{field.FieldID},{field.View},{field.DAC}");
                        }
                        writer.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error occured while getting metadata for {entity}: {e.Message}");
                    }
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //we use logout in finally block because we need to always logout, even if the request failed for some reason
                if (client.TryLogout())
                {
                    Console.WriteLine("Logged out successfully.");
                }
                else
                {
                    Console.WriteLine("An error occured during logout.");
                }
            }
        }

    }
}
