using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using uChatAI.Models;

namespace uChatAI.Services
{
    public static class TranslateService
    {
        private static int retryCount = 0;
        private static readonly string URL = "https://lingva.ml/api/v1/";

        public static async Task<string?> Translate(Language source, Language target, string text)
        {
            try
            {
                string url = string.Empty;

                switch (source)
                {
                    case Language.English:
                        url = $"{URL}en/";
                        break;
                    case Language.Ukrainian:
                        url = $"{URL}ru/";
                        break;
                    case Language.Russian:
                        url = $"{URL}ru/";
                        break;
                    case Language.Arabic:
                        url = $"{URL}ar/";
                        break;
                    case Language.Chinese:
                        url = $"{URL}zh/";
                        break;
                    case Language.German:
                        url = $"{URL}de/";
                        break;
                    case Language.Hindi:
                        url = $"{URL}hi/";
                        break;
                    case Language.Japanese:
                        url = $"{URL}ja/";
                        break;
                    default:
                        url = $"{URL}auto/";
                        break;
                }

                switch (target)
                {
                    case Language.English:
                        url += "en/";
                        break;
                    case Language.Ukrainian:
                        url += "uk/";
                        break;
                    case Language.Russian:
                        url += "ru/";
                        break;
                    case Language.Arabic:
                        url += "ar/";
                        break;
                    case Language.Chinese:
                        url += "zh/";
                        break;
                    case Language.German:
                        url += "de/";
                        break;
                    case Language.Hindi:
                        url += "hi/";
                        break;
                    case Language.Japanese:
                        url += "ja/";
                        break;
                    default:
                        url += "auto/";
                        break;
                }
                url += text;

                using (var client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

                    return (string)json!["translation"] ?? "";
                }
            }
            catch (Exception ex)
            {
                if (retryCount <= 2)
                {
                    return await Translate(source, target, text);
                }
                else
                {
                    retryCount = 0;

                    System.Windows.Forms.MessageBox.Show(ex.ToString(), ex.Message, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
