using System;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class Base64Service
    {
        public Base64Service()
        {

        }


        public async Task<string> EncodeBase64(string text)
        {
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        public async Task<string> DecodeBase64(string text)
        {
            try
            {
                byte[] data = Convert.FromBase64String(text);
                return System.Text.Encoding.UTF8.GetString(data);
            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }
    }
}
