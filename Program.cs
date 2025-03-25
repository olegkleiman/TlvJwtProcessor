using Microsoft.IdentityModel.Logging;
using System.Security.Claims;
using Tlv;

namespace TlvJwtProcessorConsole
{

    internal class Program
    {

        static async Task Main(string[] args)
        {
            IdentityModelEventSource.ShowPII = true;

            string jwtString = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjdXeGNRaXBrZlEwem8xWHFMemhIUDhWSTZGUERyM2VRYlowcWVjazZfSW8iLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJiZjI3MDBlYy00ZjhjLTQ3MzEtYmQ5ZC0xOTg1MDU3Nzc4OWQiLCJpc3MiOiJodHRwczovL2IyY3RhbS5iMmNsb2dpbi5jb20vdGZwL2YxYWY0YzBjLWEyNjMtNDMzYy05YWY4LWM5YmEzMjM0NTQ3MS9iMmNfMWFfcm9wY19raWV2L3YyLjAvIiwiZXhwIjoxNzQyOTA2NzgyLCJuYmYiOjE3NDI5MDMxODEsInN1YiI6ImI3YzE5YjllLWRkYzgtNDg0Ni05ODBmLWQwYzFjMjZjZjg2MyIsInNpZ25Jbk5hbWVzLnBob25lTnVtYmVyIjoiKzk3MjU0MzMwNzAyNiIsInNpZ25Jbk5hbWVzLmNpdGl6ZW5JZCI6IjMxMzA2OTQ4NiIsInVwbiI6ImI3YzE5YjllLWRkYzgtNDg0Ni05ODBmLWQwYzFjMjZjZjg2M0BiMmN0YW0ub25taWNyb3NvZnQuY29tIiwibmFtZSI6Ik9sZWcgS2xlaW1hbiIsInNpZ25Jbk5hbWVzSW5mby5lbWFpbEFkZHJlc3MiOiJvbGVnX2tsZXltYW5AeWFob28uY29tIiwiZmFtaWx5X25hbWUiOiJLbGVpbWFuIiwiZ3JvdXBzIjoiW1wiZGd0XCIsXCJCMkMgVG9rZW4gSXNzdWVyXCJdIiwic2NwIjoiYWNjZXNzX2FsbCIsImF6cCI6ImJmMjcwMGVjLTRmOGMtNDczMS1iZDlkLTE5ODUwNTc3Nzg5ZCIsInZlciI6IjEuMCIsImlhdCI6MTc0MjkwMzE4MX0.MzUxvx_Fqvki6Tag6VwSdAHeEdiZAGFzVw-ryVpjN4tcTw3n-550mNR-wzIugsR4gFbUu3L1dP_vzsilRJrBEUOJsALqxD7usF-_ZUGAihz6O4RuKgVRY5K_josA0Hiw2vshbMpdzf3Wr-uD2GeO5pXTQWuipLVnck-cmQRoLmsW33YkH2N8bGMXYJnnEnpE8GiEBPxAOw8IFDgmMLHwmmkfpJNuN1dUg-3oVFX0Apj5Xou6FyrqzZXLfiQfQJimvkNKu7R07arqC67fQmpMVPuBzYP1QYJVZ-5PaKXVf7XNbhmTFH5dU_zqCaYA2sXY8A0LbCRHCe7oK4uXgt2C9A";

            try
            {
                var jwtProcessor = new TlvJwtProcessor(jwtString);
                ClaimsPrincipal? principal = await jwtProcessor.Validate();

                // Extract custom from JWT claims
                var userID = principal?.FindFirst("signInNames.citizenId")?.Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
